# PDFsharp issue submission template

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

See also: http://sscce.org/

## Start with our Issue Submission Templates

We have created a solution for PDFsharp and MigraDoc issue reporting.
Basically the solution contains minimal PDFsharp and MigraDoc programms, one for every build (Core, GDI+, and WPF).

1. Download the solution from https://github.com/empira/PDFsharp.IssueSubmissionTemplate
1. Add your code that reproduces the issue
1. Ececute `.\dev\zip-solution.ps1` to zip the solution
1. Send us the zip file
 