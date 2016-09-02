# Journal-Life-Archive

Life Archive is a journal where you can save life events in text and pictures. 

![Preview](http://i.imgur.com/M7zXxf1.png)

Features: 
- Text entries that can be searched
- Add pictures to any entry
- Picture captions


Text entries are saved in text files in a respective date folder. Images that are added to an entry are copied losslessly to that folder. Captions can be written for images, and those are saved in XML format.
All entries are saved in C:\Users\xxxxxx\Documents\Journal\Entries. 


Future features: 
- Video support
- Text and pictures shown together
- Preference setting to change default entry save directory (current default is C:\Users\xxxxx\Documents\Journal\Entries).
- Keywords for text and pictures for better searchability
- Collapsible year folders to reduce clutter if there are a lot of entries. 


Known bugs: 
- List of pictures for an entry will reload/flicker when a picture is deleted from that list. 
- Memory leak when thumbnails are created for newly added pictures.