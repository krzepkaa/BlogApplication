# BlogApplication
ASP.NET Projekt zaliczeniowy

1.Po otworzeniu solution, należy w appsettings.json ustawić odpowiednio ścieżkę bazy danych.<br/>
2. Wpisanie komend 'Update-database -context BlogDbContext' oraz 'Update-database -context PostDbContext'.<br/>
3. Aby móc korzystać z bloga, najpierw należy się zarejestrować i zalogować.<br/>
4. Wymagane są pola tytułu oraz treści, autor nadawany jest na bazie aktualnie dodanego użytkownika i nie można go zmienić.<br/>
5. W Admin Panel można usuwać użytkowników oraz widzieć ich dokładne ID oraz email (autoryzacja na podstawie roli admin niestety nie chce działać więc jest pominięta dla pełnej funkcjonalności strony).<br/>
6. Aby uzyskać API, należy wejść pod stronę 'https://localhost:44380/api/getusers', która podaje wszystkich userów obecnie.
