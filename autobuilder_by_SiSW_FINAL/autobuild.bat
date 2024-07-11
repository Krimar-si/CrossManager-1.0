echo !!!! Pripravi App.xaml.cs !!!!
del ".\kross_manager\CrossManager_WPF_GUI\App.xaml.cs"
TYPE App_part1 >> ".\kross_manager\CrossManager_WPF_GUI\App.xaml.cs"
echo %1 >> ".\kross_manager\CrossManager_WPF_GUI\App.xaml.cs"
echo ; >> ".\kross_manager\CrossManager_WPF_GUI\App.xaml.cs"
TYPE App_part2 >> ".\kross_manager\CrossManager_WPF_GUI\App.xaml.cs"


echo !!!! Build programa !!!!
"C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE/devenv.com"  ".\kross_manager\CrossManager.sln" /Clean
"C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE/devenv.com"  ".\kross_manager\CrossManager.sln" /Rebuild "Release"


echo !!!! Posodobi folder publish-cd !!!!
copy /y ".\kross_manager\CrossManager_WPF_GUI\bin\Release\CrossManager_WPF_GUI.exe" ".\publish_cd\03_CrossManagerSetup\CrossManager_WPF_GUI.exe"

echo !!!! Kopiraj na CD !!!!
del ".\CrossManager.iso"
.\MagicISO\miso.exe CrossManager.iso -a ".\publish_cd\01_Programi" -a ".\publish_cd\02_Pomoc" -a ".\publish_cd\03_CrossManagerSetup" -a ".\publish_cd\autorun.dat" -a ".\publish_cd\AutoRun.exe" -a ".\publish_cd\autorun.inf" -a ".\publish_cd\AutoRunV.dll" -a ".\publish_cd\MGA_logo.gif" -a ".\publish_cd\trophy.ico" -l "CrossManager"

echo !!!! Generiraj serijsko kodo !!!!
del ".\serial.txt"
echo %1 >> ".\serial.txt"
.\SN_Generator\SNGenerator.exe >> ".\serial.txt"

echo !!!! KONEC !!!!