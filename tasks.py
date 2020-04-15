#!/usr/bin/env python
# -*- coding: utf-8 -*-

# Runs great on Python 3.6.4

from invoke import task
import os
import re
import xml.etree.ElementTree as ET
import codecs

dirname = os.path.dirname(os.path.abspath(__file__))


def readAllText(fp):
    f = codecs.open(fp, "r", "utf-8")
    text = f.read()
    f.close
    return text


def writeAllText(fp, text):
    f = codecs.open(fp, "w", "utf-8")
    f.write(text)
    f.close()


def extractPublicConstStringPairs(text):
    pairs = {}
    for match in re.findall("public\\s+const\\s+string\\s+(\\w+)\\s*=\\s*\"([^\"]+)\";", text):
        pairs[match[0]] = match[1]
    return pairs


def getPdfSharpWpfVersion():  # kenjiuno.PdfSharp-WPF
    text = readAllText(os.path.join(
        dirname, "PDFsharp/code/PdfSharp/PdfSharp/ProductVersionInfo.cs"))
    pairs = extractPublicConstStringPairs(text)
    return "%s.%s.%s" % (pairs["VersionMajor"], pairs["VersionMinor"], pairs["VersionBuild"])


def updatePublicConstStringPairs(text, pairs):
    for key, value in pairs.items():
        text = re.sub(
            "\\bpublic\\s*const\\s*string\\s*" +
            re.escape(key) + "\\s*=\\s*\"[^\"]*\"\\s*;",
            "public const string " + key + " = \"" + value + "\";",
            text,
            0,
            re.MULTILINE
        )
    return text


def setPdfSharpWpfVersion(version):  # kenjiuno.PdfSharp-WPF
    filePath = os.path.join(
        dirname, "PDFsharp/code/PdfSharp/PdfSharp/ProductVersionInfo.cs")
    text = readAllText(filePath)
    versionNumbers = (version + ".0.0.0").split('.')
    text = updatePublicConstStringPairs(text, {
        "VersionMajor": versionNumbers[0],
        "VersionMinor": versionNumbers[1],
        "VersionBuild": versionNumbers[2],
    })
    writeAllText(filePath, text)

    filePath = os.path.join(
        dirname, "PDFsharp/code/PdfSharp/PdfSharp-WPF.csproj")
    text = readAllText(filePath)
    text = updatePackageVersion(text, "PackageVersion", version)
    writeAllText(filePath, text)


def extractAssemblyAttributePairs(text):
    pairs = {}
    for match in re.findall("^\\s*\\[\\s*assembly:\\s*(\\w+)\\s*\\(\\s*\"([^\"]*)\"\\s*\\)\\s*\\]", text, re.MULTILINE):
        pairs[match[0]] = match[1]
    return pairs


def getPdfSharpXpsVersion():  # kenjiuno.PdfSharp.Xps
    text = readAllText(os.path.join(
        dirname, "PDFsharp/code/PdfSharp.Xps/Properties/AssemblyInfo.cs"))
    pairs = extractAssemblyAttributePairs(text)
    return pairs["AssemblyVersion"]


def updatePackageVersion(text, elementName, value):
    text = re.sub(
        "<" + re.escape(elementName) +
        ">[^<]+</" + re.escape(elementName) + ">",
        "<" + (elementName)+">" + value + "</" + (elementName) + ">",
        text,
        0,
        re.MULTILINE
    )
    return text


def updateAssemblyAttribute(text, key, value):
    text = re.sub(
        "^\\s*\\[\\s*assembly:\\s*" +
        re.escape(key) + "\\s*\\(\\s*\"([^\"]*)\"\\s*\\)\\s*\\]",
        "[assembly: " + key + "(\"" + value + "\")]",
        text,
        0,
        re.MULTILINE
    )
    return text


def setPdfSharpXpsVersion(version):  # kenjiuno.PdfSharp.Xps
    filePath = os.path.join(
        dirname, "PDFsharp/code/PdfSharp.Xps/Properties/AssemblyInfo.cs")
    text = readAllText(filePath)
    text = updateAssemblyAttribute(text, "AssemblyVersion", version)
    writeAllText(filePath, text)

    filePath = os.path.join(
        dirname, "PDFsharp/code/PdfSharp.Xps/PdfSharp.Xps.csproj")
    text = readAllText(filePath)
    text = updatePackageVersion(text, "PackageVersion", version)
    writeAllText(filePath, text)


def updateProjectDependencies(projectFilePath):
    filePath = os.path.join(dirname, projectFilePath)
    tree = ET.parse(filePath)
    project = tree.getroot()
    changes = 0
    if project is not None:
        packages = project.findall("./ItemGroup/PackageReference")
        for package in packages:
            id = package.attrib["Include"]
            if id in assemblies:
                currentVersion = package.attrib["Version"]
                newVersion = assemblies[id]["getver"]()
                if currentVersion != newVersion:
                    package.attrib["Version"] = newVersion
                    changes += 1
    if changes != 0:
        tree.write(filePath, "UTF-8")


def updateNuspecs():
    updateProjectDependencies('PDFsharp/code/PdfSharp.Xps/PdfSharp.Xps.csproj')


assemblies = {
    "kenjiuno.PdfSharp-WPF": {
        "getver": (lambda: getPdfSharpWpfVersion()),
        "setver": setPdfSharpWpfVersion
    },
    "kenjiuno.PdfSharp.Xps": {
        "getver": (lambda: getPdfSharpXpsVersion()),
        "setver": setPdfSharpXpsVersion
    },
}
assemblyAliases = {
    "wpf": "kenjiuno.PdfSharp-WPF",
    "xps": "kenjiuno.PdfSharp.Xps",
}


@task()
def ver(c):
    """
    Display every version of assemblies
    """
    for assembly, operations in assemblies.items():
        print("%s %s" % (assembly, operations["getver"]()))


@task(help={'assembly': 'Target assembly', 'version': 'New version'})
def setver(c, assembly, version):
    """
    Update the version of specified assembly
    """
    if assembly in assemblyAliases:
        assembly = assemblyAliases[assembly]
    (assemblies[assembly])["setver"](version)

    updateNuspecs()


def calcDays():
    """
    Compute days count since 2005/01/01
    """
    import datetime
    a = datetime.datetime(2005, 1, 1)
    b = datetime.datetime.now()
    return ((b-a).days)


@task()
def days(c):
    """
    Display days count since 2005/01/01
    """
    print(calcDays())


@task()
def updateNuspecDependencies(c):
    updateNuspecs()


def bumpWpf():
    it = assemblies["kenjiuno.PdfSharp-WPF"]
    [major, minor, rev] = (it["getver"]()).split('.')
    rev = max(int(rev) + 1, calcDays())
    it["setver"]("%s.%s.%s" % (major, minor, rev))


def bumpXps():
    it = assemblies["kenjiuno.PdfSharp.Xps"]
    [major, minor, rev] = (it["getver"]()).split('.')
    rev = max(1, int(rev) + 1)
    it["setver"]("%s.%s.%s" % (major, minor, rev))


@task()
def bump(c):
    """
    Bump versions automatically
    """
    bumpWpf()
    bumpXps()

    updateNuspecDependencies(c)
    ver(c)
