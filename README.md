# Regex-App
Regex Application is an application created using ASP NET (MVC). This application allows testing a regular expression.
Home:
![image](https://github.com/janina280/Regex-App/assets/80193137/b722bb0e-460b-465c-9fa2-97a453505ce1)

The application contains 3 inputs:

- the first input represents the pattern to be entered,

- the second input represents Text1

- the third input represents Text2

Matched indicates that Text1 matches the pattern. It has a default value of "Not verified".

Matches extracts from Text2 all the strings that meet the pattern and displays them.

The Home controller is called on the "/" route. From the Index method, the view described above is returned. Which uses Form model.

To validate textures, we use Regex from System.Text. We use a validation method to validate the pattern. If this is valid, a regex instance is formed that helps us validate the first text and extract matches for the second text
