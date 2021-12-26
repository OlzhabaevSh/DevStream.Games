# DevStream game services

## Introduction

This repository provides the apps you can use for monitoring and save some data
The basic princip of development is making apps really simple to use and integrate to your own systems and application 

For example:
DevStream.Games.Twitch.ConsoleApplication - is console application wich can be used as demon tools for downloading data and save it in your filesystem.
Export format datas: [json, xml, csv]
You are able to configure export type and path to save by sending parameters into this app.

## How to setup
This repo contains no external dependensies. You can just download and build. 

.net 5

## How to run
For running you should just call the exe app with arguments in terminal:
For example:
```powershell
DevStream.Games.Twitch.ConsoleApplication --help
```
or
```powershell
DevStream.Games.Twitch.ConsoleApplication --is-show-data false --is-export true --export-type json --path-with-filename D:/your-path/file-name
```

## how to use
In this repo you can see some web client services and textformat providers witch are used in console application.
Use cases:
You can add libs yo your own app and run it by timer
Or you can configure your windows machine with task scheduler and run this app with params. Collect data by files and after use these files in your system.
In the future we will think additional intergration methods or you can contribute a new one.

## How to contribute

to be continued