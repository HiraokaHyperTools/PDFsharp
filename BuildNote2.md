# Note: Prepare publishing them to nuget.org

Tasks:

Python 3.6.x in PATH.

```bat
pip install invoke
inv bump
```

Commit changes and push it.

Azure DevOps Pipelines (Release CD) will build nupkgs and publish them to nuget.org.
