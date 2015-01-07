N.B. - WindowClicker's text recognition feature relies on Tesseract OCR application. This is included here if you don't already have it. Ensure that WindowClicker is using the correct location by using the 'Options' window.

In order to use WindowClicker:
	1.	Ensure that both WindowClicker and the target GUI are visible on screen (this obviously works better with two screens or a small target).
	2.	Press one of the six test type buttons. It will record:
		a.	A single left or right click (use this if you want to press a button etc.).
		b.	A double click.
		c.	A sequence of clicks, such as right clicking and then clicking a menu item. NB – you will need to press this button again at the end of your sequence to switch off the recording.
		d.	Static text – this gives a dialog for text that will be pasted into the target. Afterwards click where you want the text to be pasted.
		e.	File content – use this to paste data from a file. It will take the file name and then the location for pasting. It will cycle through and paste each line from the file in turn.
		f.	Loop data – use this to paste a range of incrementing/decrementing numbers. Enter data into the dialog and then click the desired location.
	3.	The Options dialog allows you to add a pause (in milliseconds) between each event if you want to.
	4.	You can send a ‘select all’ event or ‘deselect all’ event before any text is pasted for the Static/File/Loop tests. This can be set globally using the Options dialog or for each individual test using the Properties dialog. Select all would be useful when you wish to overwrite data already in place in a text box, deselect all would be useful when you want to keep adding to text present in a control to attempt to cause an overflow or error.
	5.	Events/tests are added to a treeview (as shown below) so that you can cause child event/tests to be executed. For instance:
		a.	A parent file event can have a child click event so that each time a line of text from a file is pasted into a control a button can be pressed.
		b.	File or Loop events can have child events to allow tests to be carried out with each loop increment or new file line.
	6.	Each event can be repeated from 1 to 99999 times by changing the value in its Properties dialog.
	7.	You can use the GUI monitor features to terminate testing when:
		a.	A new window appears, whose title contains text specified by you.
		b.	An existing window specified by you closes or changes its title.
		c.	The text within a selected area on screen changes (using 'snip' tool and OCR).
	8.	The GUI monitor can include multiple checks and can be set to terminate when either one or all conditions are met.
	9.	Once you click ‘Go’ just let it proceed – don’t touch the mouse or keyboard! (unless you wish to stop it with the Pause or Cancel buttons)

While running the test you may need a book to read while you wait depending on the number of tests as any attempt to use the mouse/keyboard or interact with the GUI will disrupt operation.

It’s possible to save a test tree and reload it later, but obviously the target GUI would need to be in exactly the same place (although theoretically you could change the X and Y pos for each event with the Properties dialog if you're so inclined).


