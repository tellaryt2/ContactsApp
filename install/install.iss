[Setup]
AppId={{4558E2B9-5149-47B2-B0C0-A7ECF45FCF32}
AppName=ContactsApp
AppVersion=1.1
AppPublisher=ArtemCapcom, Inc.
AppPublisherURL=https://github.com/tellaryt2/ContactsApp/
AppSupportURL=https://github.com/tellaryt2/ContactsApp/
AppUpdatesURL=https://github.com/tellaryt2/ContactsApp/
DefaultDirName={autopf}\/Minnebaev Artem/ContactsApp
ChangesAssociations=yes
DefaultGroupName=ContactsApp
AllowNoIcons=yes
OutputDir=.\Output
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\src\ContactsApp\ContactsApp.View\bin\Debug\ContactsApp.View.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\src\ContactsApp\ContactsApp.View\bin\Debug\*.dll"; DestDir: "{app}";


[Icons]
Name: "{group}\ContactsApp"; Filename: "{app}\ContactsApp.View.exe"
Name: "{autodesktop}\ContactsApp"; Filename: "{app}\ContactsApp.View.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\ContactsApp.View.exe"; Description: "{cm:LaunchProgram,ContactsApp}"; Flags: nowait postinstall skipifsilent

