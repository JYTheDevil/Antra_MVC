# MovieShopSPA

* .NET Teams C# => Angular => Typescript (Strongly typed)
* 2011 => Google created AngularJS => 1, 1.1, 1.2...1.6 => JavaScript
* 2016 => Angular 2 => 6 months they release new version 12 => Typescript 
* Typescript (Microsoft) => Strongly Typed and SuperSet of JS 
### Traditional vs SPA
Traditional web application => ASP.NET MVC, JSP => 
we write code that runs on the server, and the server will return HTML to the browser
whole page is gonna be re loaded
Movie Details Page => View and header

Single Page Application (SPA)
50 pages 
you create all the HTML with JS/Typescript
movieshop.com 
make http request to the server where angular is hosted
send the response to the browser, its gonna send all the HTML/JS/CSS code for all the 50 pages
to the browser

10:00 AM => first load 250 pages inside the browser (Home.html, genres.html, moviedtail.html)
 20 movies => make an AJAX request to get the json data show the page 
10:05 => movieshop.com/movies/22 => get the json data
10:06 => movieshop.com/movies/45

#### Modularize our application based on business rules or roles

* Anonymous role 
* User Loged in
* Admin

App Module => Default Module
Account Module => login, register 
Admin Module => CreateMovie, CreateCast, GetMostPurchadedMovies
User Module => Purchases, Favorites, Profile, EditProfile
Home Module => Home Page, Movie Details, CastDetails


10:00 movieshop.com => HomeModule
10:05 movieshop.com/user/purchases => canLoad =>if user is already logedin =>  User Module
10:10 movieshop.com/admin/createmovie => if user is loged in, user has role of admin => Admin 



### Useful VS Code Extensions

1. https://marketplace.visualstudio.com/items?itemName=Mikael.Angular-BeastCode
2. https://marketplace.visualstudio.com/items?itemName=Angular.ng-template
3. https://marketplace.visualstudio.com/items?itemName=infinity1207.angular2-switcher
4. https://marketplace.visualstudio.com/items?itemName=formulahendry.auto-close-tag
5. https://marketplace.visualstudio.com/items?itemName=formulahendry.auto-rename-tag
6. https://marketplace.visualstudio.com/items?itemName=thekalinga.bootstrap4-vscode
7. https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons
8. https://marketplace.visualstudio.com/items?itemName=christian-kohler.path-intellisense

> Angular uses 4200 port number by default
### Every Angular application needs to have at-least one Module
| Angular      | dotnet C#            |
|--------------|----------------------|
| Decorators   | Attributes           |
| Components   | Controllers          |
| Templates    | Views                |
| Services     | Services             |
| Interceptors | Middlewares          |
| Route Guards | Authorize Filters    |
| DI           | DI                   |
| Task         | Observables/Promises |


XMLHttpRequest => Ajax Http call

HttpClient => Abstraction of XMLHttpRequest

Always prefer to use Services to make the call to API as they isolate business logic from Components UI Logic
In Angular we use HttpClient to call our API to get the json data

Feature Folders/modules => based on our Business/Domain logic

MovieCard as it can be used across multiple components, we create it in Shared foler

In Angular **Directives** they provide some special functionaity to existing HTML/DOM

<a href="google.com" id="someid" name="soemname" mycustom = "angualrcode"  > Google </a>

Angualr has some built-in directives => 
1. ngFor (list of purchase, favotites, home page)
2. ngIf (navbar if use is auth => his/her name if not login and register button)
3. ngSwitch
4. ngModel
5. ngClass
6. ngStyle

#### Component Communication

Parent Component => Child Component passing data from parent to child component we use @input
HomeComponent => MovieCardComponent 

For emiting a event from child to parent we use @output

When you go to localhost:4200 => AppModule => HomeComponent

localhost:4200/movies/details/3 => MovieDetailsComponent => MoviesModule