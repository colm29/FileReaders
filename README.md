## FileReaders Solution
This Project contains 2 projects.  The *Fileparser* project, which is a .NET Core console app can be run which will call 2 reader methods.  The first will output the location fields from the EDI File stored in the project and the second will output the relevant values from the XML file accoding to the element attribute values.

The second project in the solution is the *WebAPI* project.  This is the basic .NET Core API template with some modifications.  Passing plain text XML has been enabled by creating a *RawRequestBodyInputFormatter* class and enabling this in the  *Startup.cs* class.  The Post method in the *ValuesController* class makes use of this to accept the text posted in the request body and converts it into an *XDocument* and then queries the elements, returning the relevant the relevant result code. When the project is run the browser will open on http://localhost:49749/api/values and the XML text can be passed as *text/plain* the request body in an application like Postman.
