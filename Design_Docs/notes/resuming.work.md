## Purpose of Document

This doc serves as a refresher to get myself back in working mode for this Spreadsheet App.

## Review of Work

### Monday, July 11 2022

I left this application 2 weeks ago, after implementing a rough version of the Expression Tree constructor.  I have no idea whether it actually works.  I only wrote the code; I did not test it at all since I needed a break after working on it non-stop for one week.  I called it 'good' at the time as I prepared to go back to Pullman.

During that short period of one week, I worked hard to implement the logic and got something out of it.  I think I have a pretty streamlined design with well decoupled components.  I also implemented forward-thinking design that is actually more complex than asked in the requirement document.  The requirement doc only asked us to parse and tokenize the string and construct the tree immediately.  On the other hand, I implemented a parser class to decompose the string expression and process it into a node-based expression before constructing the tree from that.  Thus, the code base of the tree is quite lightweight.  It only involves operations that manipulate the tree's content.  The parsing job is offloaded to the parser (naturally).  From this, I also realized that I severely underestimated the amount of work required for implementing the parser.  It was a lot more complicated than I thought.

Perhaps, I can start there: read through the parser class code to refamiliarize myself.
