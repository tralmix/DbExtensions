# DbExtensions

[![.NET](https://github.com/tralmix/DbExtensions/actions/workflows/dotnet.yml/badge.svg)](https://github.com/tralmix/DbExtensions/actions/workflows/dotnet.yml)
[![CodeFactor](https://www.codefactor.io/repository/github/tralmix/dbextensions/badge)](https://www.codefactor.io/repository/github/tralmix/dbextensions) 

## About
This repository is just a collection of extensions to the .Net `System.Data` namespace that I have found useful and got tired of rewriting in new projects. 

## Features
Included are wrappers to the Get methods on `DbDataReader` to allow for returning nullable types and accounting for `DbNull` being returned from the database.

Also included are retry methods wrappers for various base methods. The retry methods have an exponential backoff at a rate of 2<sup>n</sup> up to n = 8.  If you wish more control I would recommend you look have a look at [Polly](https://github.com/App-vNext/Polly).
