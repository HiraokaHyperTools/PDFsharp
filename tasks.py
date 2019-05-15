from invoke import task
import os
import re

dirname = os.path.dirname(os.path.abspath(__file__))

def readAllText(fp):
    f = open(fp)
    text = f.read()
    f.close
    return text

def writeAllText(fp, text):
    f = open(fp, "w")
    f.write(text)
    f.close()

def extractPublicConstStringPairs(text):
    pairs = {}
    for match in re.findall("public\\s+const\\s+string\\s+(\\w+)\\s*=\\s*\"([^\"]+)\";", text):
        pairs[match[0]] = match[1]
    return pairs

def getPdfSharpWpfVersion(): # kenjiuno.PdfSharp-WPF
    text = readAllText(os.path.join(dirname, "PDFsharp/code/PdfSharp/PdfSharp/ProductVersionInfo.cs"))
    pairs = extractPublicConstStringPairs(text)
    return "%s.%s.%s" % (pairs["VersionMajor"], pairs["VersionMinor"], pairs["VersionBuild"])

def updatePublicConstStringPairs(text, pairs):
    for key, value in pairs.items():
        text = re.sub(
            "\\bpublic\\s*const\\s*string\\s*" + re.escape(key) + "\\s*=\\s*\"[^\"]*\"\\s*;",
            "public const string " + key + " = \"" + value + "\";",
            text,
            0,
            re.MULTILINE
        )
    return text

def setPdfSharpWpfVersion(version): # kenjiuno.PdfSharp-WPF
    filePath = os.path.join(dirname, "PDFsharp/code/PdfSharp/PdfSharp/ProductVersionInfo.cs")
    text = readAllText(filePath)
    versionNumbers = (version + ".0.0.0").split('.')
    text = updatePublicConstStringPairs(text, {
        "VersionMajor": versionNumbers[0],
        "VersionMinor": versionNumbers[1],
        "VersionBuild": versionNumbers[2],
    })
    writeAllText(filePath, text)

def extractAssemblyAttributePairs(text):
    pairs = {}
    for match in re.findall("^\\s*\\[\\s*assembly:\\s*(\\w+)\\s*\\(\\s*\"([^\"]*)\"\\s*\\)\\s*\\]", text, re.MULTILINE):
        pairs[match[0]] = match[1]
    return pairs

def getPdfSharpXpsVersion(): # kenjiuno.PdfSharp.Xps
    text = readAllText(os.path.join(dirname, "PDFsharp/code/PdfSharp.Xps/Properties/AssemblyInfo.cs"))
    pairs = extractAssemblyAttributePairs(text)
    return pairs["AssemblyVersion"]

def updateAssemblyAttribute(text, key, value):
    text = re.sub(
        "^\\s*\\[\\s*assembly:\\s*" + re.escape(key) + "\\s*\\(\\s*\"([^\"]*)\"\\s*\\)\\s*\\]",
        "[assembly: " + key + "(\"" + value + "\")]",
        text,
        0,
        re.MULTILINE
        )
    return text

def setPdfSharpXpsVersion(version): # kenjiuno.PdfSharp.Xps
    filePath = os.path.join(dirname, "PDFsharp/code/PdfSharp.Xps/Properties/AssemblyInfo.cs")
    text = readAllText(filePath)
    text = updateAssemblyAttribute(text, "AssemblyVersion", version)
    writeAllText(filePath, text)

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

@task()
def days(c):
    """
    Display days count since 2005/01/01
    """
    import datetime
    a = datetime.datetime(2005, 1, 1)
    b = datetime.datetime.now()
    print((b-a).days)
