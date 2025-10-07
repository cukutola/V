# Quick Start Guide - Vereinssoftware

## Installation und Ausführung

### Voraussetzungen

1. **.NET 8.0 SDK** oder höher
   - Download: https://dotnet.microsoft.com/download
   - Überprüfen: `dotnet --version`

2. **Windows Betriebssystem**
   - WPF läuft nur auf Windows

3. **Optional: Visual Studio 2022** oder höher
   - Für einfacheres Development
   - Community Edition ist kostenlos

### Projekt klonen oder herunterladen

```bash
git clone https://github.com/cukutola/V.git
cd V
```

### Projekt bauen

```bash
dotnet build Vereinssoftware.sln
```

### Anwendung starten

```bash
dotnet run --project Vereinssoftware.App
```

Oder in Visual Studio:
1. Lösung öffnen: `Vereinssoftware.sln`
2. F5 drücken oder auf "Start" klicken

## Erste Schritte

### 1. Anmelden

Beim Start der Anwendung erscheint das Login-Fenster.

**Standard-Zugangsdaten:**
- Benutzername: `admin`
- Passwort: `admin`

### 2. Hauptfenster

Nach erfolgreichem Login öffnet sich das Hauptfenster mit folgenden Menüpunkten:

- **Mitglieder**: Verwaltung der Vereinsmitglieder
- **Benutzer**: Verwaltung der System-Benutzer (nur für Admins)
- **Verein**: Verwaltung der Vereinsinformationen

### 3. Mitgliederverwaltung

**Mitglieder anzeigen:**
- Automatische Anzeige aller Mitglieder beim Öffnen
- Beispiel-Mitglieder sind bereits vorhanden

**Neues Mitglied hinzufügen:**
1. Klicken Sie auf "Hinzufügen"
2. Ein neues Mitglied wird mit Standardwerten erstellt
3. Bearbeiten Sie die Daten direkt im DataGrid
4. Klicken Sie "Bearbeiten" zum Speichern

**Mitglied bearbeiten:**
1. Wählen Sie ein Mitglied aus der Tabelle
2. Ändern Sie die Werte direkt in den Zellen
3. Klicken Sie "Bearbeiten" zum Speichern

**Mitglied löschen:**
1. Wählen Sie ein Mitglied aus der Tabelle
2. Klicken Sie auf "Löschen"

**Mitglieder suchen:**
1. Geben Sie Text in das Suchfeld ein
2. Die Liste wird automatisch gefiltert
3. Suche durchsucht Vorname, Nachname und E-Mail

### 4. Benutzerverwaltung (nur Admins)

**Neuen Benutzer hinzufügen:**
1. Klicken Sie auf "Benutzer hinzufügen"
2. Ein neuer Benutzer wird erstellt
3. Bearbeiten Sie die Daten im DataGrid
4. Standard-Passwort ist "passwort"

**Benutzer löschen:**
1. Wählen Sie einen Benutzer aus
2. Klicken Sie auf "Löschen"
3. Der Admin-Benutzer kann nicht gelöscht werden

**Benutzerrollen:**
- **Admin**: Vollzugriff
- **Moderator**: Zugriff auf Mitglieder und Verein
- **Member**: Eingeschränkter Zugriff

### 5. Vereinsverwaltung

**Vereinsdaten bearbeiten:**
1. Klicken Sie auf "Verein" im Menü
2. Bearbeiten Sie die Felder:
   - Name
   - Beschreibung
   - Adresse
   - Telefon
   - E-Mail
   - Website
   - Gründungsdatum
3. Klicken Sie auf "Speichern"

### 6. Abmelden

Klicken Sie auf "Abmelden" in der rechten oberen Ecke um sich abzumelden.

## Tipps und Tricks

### Tastenkombinationen

- **Enter** im Login-Fenster: Anmelden
- **Tab**: Navigation zwischen Feldern

### DataGrid-Bearbeitung

- **Doppelklick**: Zelle bearbeiten
- **Tab**: Nächste Zelle
- **Enter**: Zeile abschließen

### Benutzerrollen testen

1. Erstellen Sie einen neuen Benutzer mit Rolle "Member"
2. Melden Sie sich ab
3. Melden Sie sich mit dem neuen Benutzer an
4. Beobachten Sie, dass der "Benutzer"-Menüpunkt versteckt ist

## Häufige Probleme

### Build-Fehler: "Cannot find SDK"

**Lösung:** Installieren Sie .NET 8.0 SDK
```bash
dotnet --version
```

### Anwendung startet nicht

**Lösung:** Stellen Sie sicher, dass Sie Windows verwenden (WPF-Anforderung)

### "Ungültiger Benutzername oder Passwort"

**Lösung:** 
- Benutzername: `admin`
- Passwort: `admin`
- Beachten Sie Groß-/Kleinschreibung

### DataGrid zeigt keine Daten

**Lösung:** Klicken Sie auf den entsprechenden Menüpunkt erneut oder starten Sie die Anwendung neu

## Daten-Persistenz

**Wichtig:** Die aktuelle Version speichert alle Daten im Arbeitsspeicher.

Das bedeutet:
- Alle Änderungen gehen beim Beenden verloren
- Beim nächsten Start sind wieder die Standard-Daten vorhanden

Für permanente Speicherung müsste eine Datenbankanbindung implementiert werden.

## Weitere Informationen

- **Architektur**: Siehe `ARCHITECTURE.md`
- **README**: Siehe `README.md`
- **Code-Dokumentation**: Inline-Kommentare im Code

## Support

Bei Fragen oder Problemen:
1. Überprüfen Sie die Dokumentation
2. Schauen Sie sich den Code an
3. Erstellen Sie ein Issue auf GitHub

## Next Steps

Nach dem Kennenlernen der Grundfunktionen können Sie:

1. **Eigene Benutzer anlegen** mit verschiedenen Rollen
2. **Mitglieder-Datenbank aufbauen** mit realen Daten
3. **Vereinsinformationen anpassen** für Ihren Verein
4. **Code erweitern** mit zusätzlichen Features
5. **Datenbank anbinden** für persistente Speicherung

Viel Erfolg mit der Vereinssoftware!
