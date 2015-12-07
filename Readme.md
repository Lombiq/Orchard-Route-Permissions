# Orchard Route Permissions Module Readme



## Project Description

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

The module's source is available in two public source repositories, automatically mirrored in both directions with [Git-hg Mirror](https://githgmirror.com):

- [https://bitbucket.org/Lombiq/orchard-route-permissions](https://bitbucket.org/Lombiq/orchard-route-permissions) (Mercurial repository)
- [https://github.com/Lombiq/Orchard-Route-Permissions](https://github.com/Lombiq/Orchard-Route-Permissions) (Git repository)

Bug reports, feature requests and comments are warmly welcome, **please do so via GitHub**.
Feel free to send pull requests too, no matter which source repository you choose for this purpose.

This project is developed by [Lombiq Technologies Ltd](http://lombiq.com/). Commercial-grade support is available through Lombiq.