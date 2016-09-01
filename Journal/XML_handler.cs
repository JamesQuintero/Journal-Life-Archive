//handles captions for images through XML files. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Journal
{
    class XML_handler
    {

        public XML_handler()
        {
            
        }
        

        public string get_caption(string xml_path, string image_path)
        {
            create_xml_captions_doc(xml_path);

            var doc = XDocument.Load(xml_path);

            var images = doc.Descendants("image");
            foreach (var image in images)
            {
                string path = image.Element("path").Value;

                if (path == image_path)
                    return image.Element("caption").Value;
            }
            
            return "";
        }

        //creates the xml file with default element structure
        private void create_xml_captions_doc(string path)
        {
            if (File.Exists(path)==false)
            {
                XDocument doc =
                  new XDocument(
                    new XElement("entry",
                      new XElement("info", "")
                    )
                  );

                doc.Save(path);
            }
        }

        //adds caption to xml if not empty
        public void add_caption(string xml_path, string image_path, string caption_text)
        {
            //adds caption if it doesn't exist
            if (get_caption(xml_path, image_path) == "" && caption_text != "")
            {
                XDocument doc = XDocument.Load(xml_path);
                XElement info = doc.Root.Element("info");

                info.Add(
                    new XElement("image",
                        new XElement("path", image_path),
                        new XElement("caption", caption_text)
                    )
                );

                doc.Save(xml_path);
            }
            //edits caption if it does exist
            else if (caption_text != "")
            {
                XDocument doc = XDocument.Load(xml_path);

                var images = doc.Descendants("image");
                foreach (var image in images)
                {
                    string path = image.Element("path").Value;

                    if (path == image_path)
                    {
                        image.Element("caption").Value = caption_text;
                        break;
                    }
                }

                doc.Save(xml_path);
            }
            else if (caption_text == "")
                remove_caption(xml_path, image_path);

        }

        //removes caption from xml if caption is empty
        public void remove_caption(string xml_path, string image_path)
        {
            create_xml_captions_doc(xml_path);

            var doc = XDocument.Load(xml_path);

            var images = doc.Descendants("image");
            foreach (var image in images)
            {
                string path = image.Element("path").Value;

                if (path == image_path)
                {
                    image.Remove();
                    break;
                }
            }
            
            doc.Save(xml_path);


        }


    }
}
