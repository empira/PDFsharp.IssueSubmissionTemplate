﻿# PDFsharp issue submission template

It is very difficult for us to fix a bug which we cannot replicate.
We cannot even test whether the bug was fixed if we cannot replicate it.
In the best case, when submitting a bug report, provide us a solution that allows us to replicate the bug.

Many people showed us a few lines of their code on the forum.
In many cases, the code was running fine after we built an application around the code snippet.
The problem was with the code that was not shown - and we wasted our time.

## Make the issue reproducible

The key to have an issue resolved is to make it reproducible.

On Stack Overflow this is know as MCVE: a **Minimal**, **Complete**, and **Verifiable** Example  
[MCVE on Stack Overflow](https://stackoverflow.com/help/minimal-reproducible-example)

See also: <http://sscce.org/>

## Start with our Issue Submission Templates

We have created a solution for PDFsharp and MigraDoc issue reporting.
Basically the solution contains minimal PDFsharp and MigraDoc programs, one for every build (Core, GDI+, and WPF). Thus there are six projects in the solution.

1. Download the solution from <https://github.com/empira/PDFsharp.IssueSubmissionTemplate>
1. Add your code that reproduces the issue
1. Execute `.\dev\zip-solution.ps1` to zip the solution
1. Send us the zip file

* We prefer to receive files via <https://github.com/empira/PDFsharp/issues>
* If the zip file contains confidential data or is very large, please [upload it to our FTP server](https://docs.pdfsharp.net/General/Issue-Reporting/About.html).

The solution was developed with Visual Studio 2022. The .PS1 files in the DEV folder require PowerShell Core 7.0 or higher.

Note: The PowerShell script files included with this solution are not signed.
Set ExecutionPolicy to `Undefined` to execute them under Windows.

```pwsh
Set-ExecutionPolicy -ExecutionPolicy Undefined -Scope CurrentUser
```

## Information about the Issue Submission Template structure

We have three projects for PDFsharp, one for each of the builds **Core**, **GDI**, and **WPF**. Source code `Program.cs` is contained in the **IssueSubmission** project under **PDFsharp** only. The other projects **IssueSubmission-gdi** and **IssueSubmission-wpf** use the same `Program.cs` file by link.
Use these three projects to replicate issues with PDFsharp. The projects have references to PDFsharp only. Classes from MigraDoc should not be used here.

The same structure was also prepared for **MigraDoc**. To replicate issues with MigraDoc, use the projects listed unter **MigraDoc** that already have references to PDFsharp and MigraDoc.

Note that each project has multiple target frameworks.  
Please let us know which project and which target framework you used to replicate the issue.  
In the past we identified issues that would show with .NET Framework 4.x, but not with .NET 6 or higher while other issues showed with the WPF build, but not the Core build.

If your code only works with a specific flavor, use `#if` around your code to ensure that all six projects of the solution still compile.  
Use `#if PDFsharp_Core`, `#if PDFsharp_WPF`, or `#if PDFsharp_GDI` as needed.

Example that uses `XImage.FromGdiPlusImage` only supported by the GDI build:

```csharp
#if PDFsharp_GDI
            var bitmap = ... // Code that creates the bitmap.
            // Draw the bitmap.
            var xImage = XImage.FromGdiPlusImage(bitmap);
            gfx.DrawImage(xImage, new Point(10, 10));
#endif
```

When adding resources, like image files, we recommend to add them to the folder containing this README.md file and use relative paths beginning with `..\..\..\..\..\..\` to reference them.

Please ensure that all six projects compile without errors before submitting the issue report.

Thanks for your support.
