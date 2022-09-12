# WinForms SpreadSheet App, .NETCore6, REWORKED

This is the rework implementation of the semester project from CptS 321.  This
is the technical debt I was allowed to work on over the Summer 2022.

### 1. Requirements and Design Docs

These information can be found in the `Docs.*` folder at the root directory.

### 2. Implemented Features

- [x] *GUI Layer* (client-side)
- [x] *Logic Layer* (server-side)
- [x] Capturing and sending input from cells in the *GUI Layer* to be processed
  at the *Logic Layer*
- [x] Parsing logic to build postfix from an infix input (string captured from
  *GUI Layer*)
- [x] Full Expression Tree
- [x] Selecting and evaluating an expression via Expression Tree if started
  with `=`
- [x] Updating the content of the correct cell in *GUI Layer*
- [x] Referencing and pulling data from other cells via their coordinates for
  Expression Tree evaluation

### 3. Not Implemented Features

- [ ] Handling *circular references*
- [ ] *Undo* and *Redo* features
- [ ] *Save* and *Load* expression from XML file input.