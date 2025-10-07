# Architektur-Dokumentation - Vereinssoftware

## Übersicht

Die Vereinssoftware ist eine WPF-Anwendung, die das MVVM (Model-View-ViewModel) Pattern verwendet. Sie wurde mit C# und .NET 8.0 entwickelt.

## Architektur-Pattern

### MVVM (Model-View-ViewModel)

```
View (XAML) <--> ViewModel <--> Model/Services
```

- **Views**: XAML-Dateien für die Benutzeroberfläche
- **ViewModels**: Geschäftslogik und Datenbindung
- **Models**: Datenmodelle
- **Services**: Business-Services (z.B. Authentication)
- **Commands**: ICommand-Implementierungen für Benutzerinteraktionen

## Projekt-Struktur

```
Vereinssoftware.App/
│
├── App.xaml / App.xaml.cs
│   └── Haupteinstiegspunkt der Anwendung
│
├── Models/
│   ├── User.cs              # Benutzer-Modell mit Rollen
│   ├── Member.cs            # Mitglieder-Modell
│   └── Club.cs              # Vereins-Modell
│
├── ViewModels/
│   ├── ViewModelBase.cs     # Basis-ViewModel mit INotifyPropertyChanged
│   ├── LoginViewModel.cs    # ViewModel für Login
│   ├── MainViewModel.cs     # Hauptfenster ViewModel
│   ├── MemberManagementViewModel.cs
│   ├── UserManagementViewModel.cs
│   └── ClubManagementViewModel.cs
│
├── Views/
│   ├── LoginView.xaml       # Login-Fenster
│   ├── MainView.xaml        # Hauptfenster
│   ├── MemberManagementView.xaml
│   ├── UserManagementView.xaml
│   └── ClubManagementView.xaml
│
├── Commands/
│   └── RelayCommand.cs      # ICommand-Implementierung
│
├── Services/
│   ├── IAuthenticationService.cs
│   └── AuthenticationService.cs
│
├── Data/
│   ├── IUserRepository.cs
│   ├── IMemberRepository.cs
│   ├── IClubRepository.cs
│   ├── InMemoryUserRepository.cs
│   ├── InMemoryMemberRepository.cs
│   └── InMemoryClubRepository.cs
│
└── Converters/
    ├── BoolToVisibilityConverter.cs
    └── StringToVisibilityConverter.cs
```

## Komponenten-Beschreibung

### Models

#### User
- Repräsentiert System-Benutzer
- Eigenschaften: Id, Username, PasswordHash, FirstName, LastName, Email, Role, IsActive
- Rollen: Admin, Moderator, Member

#### Member
- Repräsentiert Vereinsmitglieder
- Eigenschaften: Id, FirstName, LastName, Email, Phone, Address, DateOfBirth, MemberSince, Status
- Status: Active, Inactive, Suspended

#### Club
- Repräsentiert Vereinsinformationen
- Eigenschaften: Id, Name, Description, Address, Phone, Email, Website, FoundedDate

### ViewModels

#### ViewModelBase
- Basis-Klasse für alle ViewModels
- Implementiert INotifyPropertyChanged
- Bietet SetProperty-Methode für Property-Änderungen

#### LoginViewModel
- Verwaltet den Login-Prozess
- LoginCommand für Authentifizierung
- ErrorMessage für Fehlermeldungen

#### MainViewModel
- Hauptfenster-ViewModel
- Navigation zwischen verschiedenen Views
- Logout-Funktionalität

#### MemberManagementViewModel
- CRUD-Operationen für Mitglieder
- Suchfunktion
- ObservableCollection für DataGrid-Bindung

#### UserManagementViewModel
- Verwaltung von System-Benutzern
- Nur für Admins sichtbar
- Hinzufügen und Löschen von Benutzern

#### ClubManagementViewModel
- Bearbeitung von Vereinsinformationen
- Speichern von Änderungen

### Services

#### AuthenticationService
- Benutzer-Authentifizierung
- Passwort-Hashing mit SHA-256
- Verwaltung des aktuellen Benutzers

### Data Layer (Repository Pattern)

#### Repositories
- Trennung von Datenzugriff und Business-Logik
- Interface-basiert für einfache Austauschbarkeit
- Aktuelle Implementierung: In-Memory (kann leicht durch Datenbank ersetzt werden)

**InMemoryUserRepository**
- Speichert Benutzer im Speicher
- Enthält Standard-Admin-Benutzer

**InMemoryMemberRepository**
- Speichert Mitglieder im Speicher
- Enthält Beispiel-Mitglieder
- Suchfunktion implementiert

**InMemoryClubRepository**
- Speichert Vereinsinformationen
- Singleton-Verein

### Commands

#### RelayCommand
- Generische ICommand-Implementierung
- Unterstützt Execute und CanExecute
- Verwendet CommandManager.RequerySuggested für CanExecute-Updates

### Views

#### LoginView
- Einstiegspunkt der Anwendung
- Benutzername und Passwort-Eingabe
- Fehlerbehandlung

#### MainView
- Hauptfenster nach Login
- Menü-Navigation
- Status-Bar mit Benutzerinformationen
- ContentControl für dynamische View-Anzeige

#### MemberManagementView
- DataGrid für Mitglieder-Anzeige
- Toolbar mit Buttons
- Such-TextBox

#### UserManagementView
- DataGrid für Benutzer
- Admin-only View

#### ClubManagementView
- Formular für Vereinsdaten
- Speichern-Button

### Converters

#### BoolToVisibilityConverter
- Konvertiert Boolean zu Visibility
- Für bedingte UI-Anzeige

#### StringToVisibilityConverter
- Konvertiert String zu Visibility
- Zeigt Elemente nur bei nicht-leerem String

## Datenfluss

### Login-Prozess
```
1. Benutzer gibt Credentials ein (LoginView)
2. LoginViewModel validiert Eingabe
3. AuthenticationService prüft Credentials
4. Bei Erfolg: MainView wird angezeigt
5. Bei Fehler: ErrorMessage wird angezeigt
```

### Mitgliederverwaltung
```
1. MemberManagementView bindet an Members ObservableCollection
2. Benutzer-Interaktion triggert Command
3. Command aktualisiert Repository
4. ViewModel lädt Daten neu
5. ObservableCollection benachrichtigt View
6. View aktualisiert DataGrid
```

### Navigation
```
1. Benutzer klickt Menü-Button (MainView)
2. Command ändert CurrentViewModel Property
3. ContentControl erkennt Änderung via DataTrigger
4. Entsprechendes Template wird geladen
5. Neue View wird angezeigt
```

## Erweiterungsmöglichkeiten

### Datenbankanbindung
- Repositories können durch Entity Framework-Implementierungen ersetzt werden
- Interfaces bleiben gleich
- Nur Data-Layer muss geändert werden

### Zusätzliche Features
- Export/Import von Daten
- Berichtsgenerierung
- E-Mail-Benachrichtigungen
- Mitgliedsbeiträge-Verwaltung
- Veranstaltungs-Management

### Sicherheit
- Passwort-Komplexitätsregeln
- Session-Management
- Audit-Logging
- Zwei-Faktor-Authentifizierung

## Best Practices

1. **Separation of Concerns**: Klare Trennung zwischen UI, Logik und Daten
2. **Dependency Injection**: Services werden als Parameter übergeben
3. **Interface-basierte Entwicklung**: Repositories verwenden Interfaces
4. **SOLID Principles**: Single Responsibility, Open/Closed, etc.
5. **Data Binding**: Keine Code-behind-Logik in Views
6. **Commands statt Events**: ICommand für bessere Testbarkeit

## Testing-Strategie

- ViewModels können isoliert getestet werden
- Mock-Repositories für Unit-Tests
- Services mit Interfaces können gemockt werden
- UI-Tests mit WPF UI Automation möglich

## Performance-Überlegungen

- ObservableCollection für automatische UI-Updates
- Lazy Loading bei großen Datenmengen
- Virtualisierung in DataGrids bei Bedarf
- Asynchrone Operationen für Datenbank-Zugriffe (bei DB-Implementierung)
