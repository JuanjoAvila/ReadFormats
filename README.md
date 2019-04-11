# ReadFormats
Reading in three differents extension files. Json , Xml and Txt.

Clone project from github:
https://github.com/JuanjoAvila/ReadFormats.git

Enter into the project and open a cmd inside.

Pull this repository with :
docker pull javilach/readformats:1

To build the project :
docker build -t javilach/readformats:1 .
or to rebuild code changes and no cache
docker build --no-cache -t javilach/readformats:1 .

And run the project :
docker run -t -i javilach/readformats:1
