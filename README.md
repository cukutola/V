# V - Vereinssoftware

Eine Vereinsverwaltungssoftware mit C# und WPF (MVVM Pattern).

## Funktionen

- **Login-System**: Sichere Benutzerauthentifizierung mit Passwort-Hashing
- **Mitgliederverwaltung**: Vollständige CRUD-Operationen für Vereinsmitglieder
- **Rechteverwaltung**: Rollenbasierte Zugriffskontrolle (Admin, Moderator, Mitglied)
- **Vereinsverwaltung**: Verwaltung von Vereinsinformationen

## Technologie

- C# .NET 8.0
- WPF (Windows Presentation Foundation)
- MVVM Pattern (Model-View-ViewModel)
- Repository Pattern für Datenzugriff

## Projekt-Struktur

```
Vereinssoftware.App/
├── Models/          # Datenmodelle (User, Member, Club)
├── ViewModels/      # View Models (MVVM)
├── Views/           # XAML Views
├── Commands/        # ICommand Implementierungen
├── Services/        # Business Logic (Authentication)
├── Data/            # Repositories (In-Memory)
└── Converters/      # XAML Value Converters
```

## Erste Schritte

### Voraussetzungen

- .NET 8.0 SDK oder höher
- Windows OS (für WPF)

### Build

```bash
dotnet build Vereinssoftware.sln
```

### Ausführen

```bash
dotnet run --project Vereinssoftware.App
```


## Benutzerrollen

- **Admin**: Vollzugriff auf alle Funktionen inkl. Benutzerverwaltung
- **Moderator**: Zugriff auf Mitglieder- und Vereinsverwaltung
- **Member**: Eingeschränkter Zugriff

## Features im Detail

### Login
- Sichere Authentifizierung mit SHA-256 Passwort-Hashing
- Validierung von Benutzername und Passwort
- Fehlerbehandlung bei ungültigen Anmeldedaten

### Mitgliederverwaltung
- Anzeige aller Mitglieder in einer übersichtlichen Tabelle
- Hinzufügen neuer Mitglieder
- Bearbeiten bestehender Mitglieder
- Löschen von Mitgliedern
- Suchfunktion nach Name oder E-Mail

### Benutzerverwaltung (nur für Admins)
- Verwaltung von System-Benutzern
- Rollenzuweisung
- Aktivieren/Deaktivieren von Benutzern

### Vereinsverwaltung
- Bearbeitung von Vereinsinformationen
- Kontaktdaten
- Gründungsdatum
- Beschreibung

## Lizenz

Dieses Projekt ist Open Source.
