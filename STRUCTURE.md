# Vereinssoftware - Struktur-Visualisierung

## Anwendungs-Flow

```
┌─────────────────────────────────────────────────────────────┐
│                      APPLICATION START                       │
└────────────────────────┬────────────────────────────────────┘
                         │
                         v
┌─────────────────────────────────────────────────────────────┐
│                      LOGIN VIEW                              │
│  ┌────────────────────────────────────────────────────┐    │
│  │  Username: [________________]                      │    │
│  │  Password: [________________]                      │    │
│  │                                                     │    │
│  │         [  Anmelden  ]                            │    │
│  │                                                     │    │
│  │  Standard: admin / admin                           │    │
│  └────────────────────────────────────────────────────┘    │
└────────────────────────┬────────────────────────────────────┘
                         │
                         │ (Authentication)
                         │
                         v
┌─────────────────────────────────────────────────────────────┐
│                      MAIN VIEW                               │
│  ┌─────────────────────────────────────────────────────┐   │
│  │  [Mitglieder] [Benutzer] [Verein]    User: Admin ▼│   │
│  └─────────────────────────────────────────────────────┘   │
│  ┌─────────────────────────────────────────────────────┐   │
│  │                                                       │   │
│  │          CONTENT AREA (Dynamic)                       │   │
│  │                                                       │   │
│  └─────────────────────────────────────────────────────┘   │
│  ┌─────────────────────────────────────────────────────┐   │
│  │  Status: Benutzer: Admin | Rolle: Admin            │   │
│  └─────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────┘
```

## Komponenten-Hierarchie

```
App.xaml
  │
  ├─> LoginViewModel
  │     │
  │     └─> LoginView
  │           │
  │           └─> [Authentication Success]
  │
  └─> MainViewModel
        │
        ├─> MemberManagementViewModel
        │     └─> MemberManagementView
        │           ├─> DataGrid (Members)
        │           └─> Toolbar (Add/Edit/Delete)
        │
        ├─> UserManagementViewModel
        │     └─> UserManagementView
        │           ├─> DataGrid (Users)
        │           └─> Toolbar (Add/Delete)
        │
        └─> ClubManagementViewModel
              └─> ClubManagementView
                    ├─> Form (Club Info)
                    └─> Save Button
```

## MVVM-Architektur

```
┌──────────────┐         ┌──────────────┐         ┌──────────────┐
│              │         │              │         │              │
│     VIEW     │<------->│  VIEWMODEL   │<------->│    MODEL     │
│    (XAML)    │ Binding │   (Logic)    │         │    (Data)    │
│              │         │              │         │              │
└──────────────┘         └──────────────┘         └──────────────┘
       │                        │                        │
       │                        │                        │
       v                        v                        v
  ┌─────────┐            ┌─────────┐            ┌─────────┐
  │LoginView│            │LoginVM  │            │  User   │
  │MainView │            │MainVM   │            │ Member  │
  │MemberMgm│            │MemberVM │            │  Club   │
  │UserMgmt │            │UserVM   │            └─────────┘
  │ClubMgmt │            │ClubVM   │
  └─────────┘            └─────────┘
                               │
                               │ uses
                               v
                         ┌─────────┐
                         │Commands │
                         │Services │
                         │  Repos  │
                         └─────────┘
```

## Daten-Fluss

```
User Action (View)
       │
       v
Command (ViewModel)
       │
       v
Service/Repository
       │
       v
Data Update (Model)
       │
       v
PropertyChanged Event
       │
       v
UI Update (View)
```

## Detaillierte Klassenstruktur

```
Vereinssoftware.App
│
├── Models
│   ├── User
│   │   ├── Id: int
│   │   ├── Username: string
│   │   ├── PasswordHash: string
│   │   ├── FirstName: string
│   │   ├── LastName: string
│   │   ├── Email: string
│   │   ├── Role: enum (Admin, Moderator, Member)
│   │   └── IsActive: bool
│   │
│   ├── Member
│   │   ├── Id: int
│   │   ├── FirstName: string
│   │   ├── LastName: string
│   │   ├── Email: string
│   │   ├── Phone: string
│   │   ├── Address: string
│   │   ├── DateOfBirth: DateTime
│   │   ├── MemberSince: DateTime
│   │   ├── Status: enum (Active, Inactive, Suspended)
│   │   └── Notes: string
│   │
│   └── Club
│       ├── Id: int
│       ├── Name: string
│       ├── Description: string
│       ├── Address: string
│       ├── Phone: string
│       ├── Email: string
│       ├── Website: string
│       └── FoundedDate: DateTime
│
├── ViewModels
│   ├── ViewModelBase
│   │   ├── INotifyPropertyChanged
│   │   ├── OnPropertyChanged()
│   │   └── SetProperty<T>()
│   │
│   ├── LoginViewModel : ViewModelBase
│   │   ├── Username: string
│   │   ├── Password: string
│   │   ├── ErrorMessage: string
│   │   ├── LoginCommand: ICommand
│   │   └── LoginSuccessful: event
│   │
│   ├── MainViewModel : ViewModelBase
│   │   ├── CurrentViewModel: ViewModelBase
│   │   ├── ShowMembersCommand: ICommand
│   │   ├── ShowUsersCommand: ICommand
│   │   ├── ShowClubCommand: ICommand
│   │   └── LogoutCommand: ICommand
│   │
│   ├── MemberManagementViewModel : ViewModelBase
│   │   ├── Members: ObservableCollection<Member>
│   │   ├── SelectedMember: Member
│   │   ├── SearchText: string
│   │   ├── AddMemberCommand: ICommand
│   │   ├── EditMemberCommand: ICommand
│   │   └── DeleteMemberCommand: ICommand
│   │
│   ├── UserManagementViewModel : ViewModelBase
│   │   ├── Users: ObservableCollection<User>
│   │   ├── SelectedUser: User
│   │   ├── AddUserCommand: ICommand
│   │   └── DeleteUserCommand: ICommand
│   │
│   └── ClubManagementViewModel : ViewModelBase
│       ├── Club: Club
│       └── SaveCommand: ICommand
│
├── Views
│   ├── LoginView.xaml
│   ├── MainView.xaml
│   ├── MemberManagementView.xaml
│   ├── UserManagementView.xaml
│   └── ClubManagementView.xaml
│
├── Commands
│   └── RelayCommand : ICommand
│       ├── CanExecute(object)
│       └── Execute(object)
│
├── Services
│   ├── IAuthenticationService
│   └── AuthenticationService
│       ├── CurrentUser: User
│       ├── IsAuthenticated: bool
│       ├── Login(username, password): bool
│       └── Logout(): void
│
├── Data (Repositories)
│   ├── IUserRepository
│   ├── IMemberRepository
│   ├── IClubRepository
│   ├── InMemoryUserRepository
│   ├── InMemoryMemberRepository
│   └── InMemoryClubRepository
│
└── Converters
    ├── BoolToVisibilityConverter
    └── StringToVisibilityConverter
```

## Navigation-Flow

```
                    ┌─────────────┐
                    │ Login View  │
                    └──────┬──────┘
                           │
                    [Login Success]
                           │
                           v
                    ┌─────────────┐
                    │  Main View  │
                    └──────┬──────┘
                           │
         ┌─────────────────┼─────────────────┐
         │                 │                 │
         v                 v                 v
    ┌─────────┐     ┌─────────┐     ┌─────────┐
    │ Members │     │  Users  │     │  Club   │
    │  View   │     │  View   │     │  View   │
    └─────────┘     └─────────┘     └─────────┘
    (All Roles)     (Admin Only)    (All Roles)
```

## Security-Layer

```
┌─────────────────────────────────────────┐
│         User Interface Layer            │
│  (Views with role-based visibility)     │
└───────────────┬─────────────────────────┘
                │
                v
┌─────────────────────────────────────────┐
│      Authentication Service Layer       │
│  - Login/Logout                         │
│  - Password Hashing (SHA-256)           │
│  - Current User Management              │
└───────────────┬─────────────────────────┘
                │
                v
┌─────────────────────────────────────────┐
│         Authorization Layer             │
│  - Role-based Access Control            │
│  - IsAdmin checks                       │
│  - Menu visibility                      │
└───────────────┬─────────────────────────┘
                │
                v
┌─────────────────────────────────────────┐
│         Data Access Layer               │
│  - Repository Pattern                   │
│  - CRUD Operations                      │
└─────────────────────────────────────────┘
```

## Datenbank-Migration (Zukünftig)

```
Current: In-Memory Storage
    │
    │  Replace Repositories
    │
    v
Future: Database Storage

InMemoryUserRepository  ──>  EfUserRepository
InMemoryMemberRepository ──> EfMemberRepository
InMemoryClubRepository   ──> EfClubRepository

Interfaces bleiben gleich!
ViewModels bleiben gleich!
Views bleiben gleich!
```

## Erweiterungs-Punkte

```
1. Neue Features
   ├─> Neue ViewModel erstellen
   ├─> Neue View erstellen
   ├─> In MainViewModel registrieren
   └─> Menü-Button hinzufügen

2. Neue Datentypen
   ├─> Neues Model erstellen
   ├─> Repository Interface erstellen
   ├─> Repository Implementierung
   └─> In App.xaml.cs registrieren

3. Neue Services
   ├─> Interface definieren
   ├─> Service implementieren
   └─> Via Konstruktor injizieren
```

## Zusammenfassung

Die Anwendung folgt einem klaren, schichtbasierten Aufbau:
- **Präsentationsschicht**: Views (XAML)
- **Logikschicht**: ViewModels & Commands
- **Service-Schicht**: Authentication & Business Logic
- **Datenschicht**: Repositories & Models

Diese Architektur ermöglicht:
✅ Einfache Wartung
✅ Gute Testbarkeit
✅ Klare Verantwortlichkeiten
✅ Hohe Erweiterbarkeit
✅ Lose Kopplung
