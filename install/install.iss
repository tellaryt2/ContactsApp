[Setup]
AppId={{4558E2B9-5149-47B2-B0C0-A7ECF45FCF32}
AppName=ContactsApp
AppVersion=1.1
AppPublisher=ArtemCapcom, Inc.
AppPublisherURL=https://www.example.com/
AppSupportURL=https://www.example.com/
AppUpdatesURL=https://www.example.com/
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
;Source: "..\src\ContactsApp\ContactsApp.View\bin\Debug\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion


[Registry]
Root: HKA; Subkey: "Software\Classes\.myp\OpenWithProgids"; ValueType: string; ValueName: "ContactsAppFile.myp"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\ContactsAppFile.myp"; ValueType: string; ValueName: ""; ValueData: "ContactsApp File"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\ContactsAppFile.myp\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\ContactsApp.View.exe,0"
Root: HKA; Subkey: "Software\Classes\ContactsAppFile.myp\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\ContactsApp.View.exe"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\ContactsApp.View.exe\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{group}\ContactsApp"; Filename: "{app}\ContactsApp.View.exe"
Name: "{autodesktop}\ContactsApp"; Filename: "{app}\ContactsApp.View.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\ContactsApp.View.exe"; Description: "{cm:LaunchProgram,ContactsApp}"; Flags: nowait postinstall skipifsilent

