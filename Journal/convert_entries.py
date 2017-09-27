import os
import sys
import shutil
import xml.etree.ElementTree


def convert_file_names():
	journal_path="./Entries"

	try:
		file_list=os.listdir(journal_path)
	except Exception as error:
		print("Can't list: "+str(error))
		return []


	for x in range(0, len(file_list)):

		date = file_list[x]

		folder_path = journal_path+"/"+date
		file_path = folder_path+"/"+date+".txt"


		split_date = date.split("-")

		month = int(split_date[0])
		day = int(split_date[1])
		year = int(split_date[2]) + 2000

		new_date = str(year)+"-"+str(month)+"-"+str(day)


		new_folder_path = journal_path+"/"+new_date
		#uses old folder path because script renames file first
		new_file_path = folder_path+"/"+new_date+".txt"


		#renames file first
		try:
			os.rename(file_path, new_file_path)
			print("Renamed "+str(file_path)+" to "+str(new_file_path))
		except Exception as error:
			print("Error renaming file: "+str(error))

		try:
			os.rename(folder_path, new_folder_path)
			print("Renamed "+str(folder_path)+" to "+str(new_folder_path))
		except Exception as error:
			print("Error renaming folder: "+str(error))


		#reads caption's xml file and replces absolute paths with relative paths
		try:
			tree_path = new_folder_path+"/metadata.xml"
			print("Modifying image paths in "+str(tree_path))

			if os.path.exists(tree_path):
				tree = xml.etree.ElementTree.parse(tree_path)
				root = tree.getroot()
				parent = root.find("info")
				image_paths = parent.findall("image/path")
				
				for element in image_paths:
					path = element.text

					split_path = path.split("\\")

					new_path = split_path[-1]

					element.text = new_path

				tree.write(tree_path)
		except Exception as error:
			print("Error converting image paths: "+str(error))





if __name__=="__main__":

	convert_file_names()