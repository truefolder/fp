// See https://aka.ms/new-console-template for more information

using CommandLine;
using TagCloud.Client.CLI;

var runner = new Runner();
Parser.Default.ParseArguments<CliOptions>(args).MapResult(runner.Run, _ => 1);