# Orchard Route Permissions Module



## About

An Orchard module for enabling permissions for routes.


## Features

- Can aggregate Markdown pages and corresponding files from a Bitbucket repository
- Options to set up mappings between local urls and repository paths as well as specifying the maximal size of files to be mirrored (if mirroring at all)


## Features

- Specify permissions for url patterns
- Url patterns can be any regular expression
- Permission handling is done with the Content Permissions part.
- Permissions can have a priority value. The order of simultaneously matching patterns is determined by taking the priority into account.
- The specified regex is sanity-checked.
- The patterns are kept in cache so there's only DB access if a pattern matches for a page load, then only a single content item is loaded (by its primary key).


## Documentation

With this module you can set up permissions for regex-defined url patterns. E.g. you can prevent access for users with the Editor role to anything under the /blog url.

After installation the module will add a new tab under the Users menu item on the admin site. You can configure route permissions from there.

You can watch a demo of the first version of this module (the current one is bit updated) as part of an [Orchard community meeting](http://youtu.be/z5iGKIguWG0?t=24m40s).


## Contributing and support

Bug reports, feature requests, comments, questions, code contributions, and love letters are warmly welcome, please do so via GitHub issues and pull requests. Please adhere to our [open-source guidelines](https://lombiq.com/open-source-guidelines) while doing so.

This project is developed by [Lombiq Technologies](https://lombiq.com/). Commercial-grade support is available through Lombiq.