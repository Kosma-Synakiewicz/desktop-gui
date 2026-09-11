1. Kalkulator prosty
Aplikacja z siatką przycisków (0-9, +, -, *, /, =, C) i polem wyświetlającym wynik.
Ćwiczy: Grid, Button.Click, obsługę zdarzeń w code-behind.
2. Lista zadań (To-Do List)
ListBox z zadaniami, pole tekstowe do dodawania nowych, przycisk "Usuń zaznaczone".
Ćwiczy: ObservableCollection, dwukierunkowe bindowanie, ListBox.SelectedItem.
3. Konwerter jednostek
Formularz z ComboBox do wyboru jednostki (km/mile, kg/lb, °C/°F) i przeliczaniem "na żywo" przy wpisywaniu wartości.
Ćwiczy: TextChanged, konwersję danych, walidację wejścia.
4. Formularz rejestracyjny z walidacją
Imię, nazwisko, e-mail, hasło + potwierdzenie, checkbox regulaminu. Błędne pola podświetlane na czerwono z komunikatem.
Ćwiczy: IDataErrorInfo lub ValidationRules, Style z Trigger.
5. Notatnik tekstowy (Mini Notepad)
TextBox (multiline) + menu Plik: Nowy, Otwórz, Zapisz, Zapisz jako, Zamknij.
Ćwiczy: Menu, OpenFileDialog/SaveFileDialog, operacje na plikach.
6. Galeria obrazów
ListBox z miniaturkami zdjęć z wybranego folderu, kliknięcie pokazuje duży podgląd w Image.
Ćwiczy: ItemsControl, DataTemplate, BitmapImage.
7. Zegar analogowy i cyfrowy
Rysowany zegar analogowy (Canvas + Line/Ellipse obracane przez RotateTransform) obok cyfrowego wyświetlacza czasu.
Ćwiczy: DispatcherTimer, transformacje, rysowanie wektorowe.
8. Baza kontaktów z bazą danych
DataGrid z listą kontaktów (imię, telefon, e-mail) połączony z SQLite lub SQL Server — dodawanie, edycja, usuwanie (CRUD).
Ćwiczy: DataGrid, Entity Framework/ADO.NET, MVVM.
9. Quiz z pytaniami wielokrotnego wyboru
Pytania ładowane z pliku XML/JSON, RadioButton na odpowiedzi, licznik punktów i podsumowanie na końcu.
Ćwiczy: deserializację danych, RadioButton.GroupName, nawigację między "ekranami" (Frame/Page lub przełączanie UserControl).
10. Edytor rysunków (Paint uproszczony)
Canvas, na którym użytkownik rysuje myszką linie/prostokąty/koła, z wyborem koloru i grubości pędzla, plus przycisk "Wyczyść".
Ćwiczy: zdarzenia myszy (MouseDown, MouseMove, MouseUp), dynamiczne tworzenie kształtów.