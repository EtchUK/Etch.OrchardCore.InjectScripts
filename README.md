# Etch.OrchardCore.InjectScripts

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that allows you to specify custom script blocks for the `<head>` or at the bottom of the page. Useful for adding third party integrations (e.g. Google Analytics).

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.InjectScripts.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.InjectScripts) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.InjectScripts.svg)](https://www.nuget.org/packages/Etch.OrchardCore.InjectScripts)

## Orchard Core Reference

This module is referencing a stable build of Orchard Core ([`1.3.0`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.3.0)).

## Installing

This module is [available on NuGet](https://www.nuget.org/packages/Etch.OrchardCore.InjectScripts). Add a reference to your Orchard Core web project via the NuGet package manager. Search for "Etch.OrchardCore.InjectScripts", ensuring include prereleases is checked.

Alternatively you can [download the source](https://github.com/etchuk/Etch.OrchardCore.InjectScripts/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.InjectScripts.

## Usage

Enable the "Inject Scripts" feature, which will make a new "Scripts" option available under the "Configuration" option in the admin dashboard menu. Within the "Scripts" section, authorised content editors can define JavaScript that will be rendered either in the `<head>` section or at the foot of the page. If the JavaScript is not rendered on the page, ensure the following snippets are in the `layout.liquid` template for your theme.

```
{% resources type: "HeadScript" %}
{% resources type: "FootScript" %}
```