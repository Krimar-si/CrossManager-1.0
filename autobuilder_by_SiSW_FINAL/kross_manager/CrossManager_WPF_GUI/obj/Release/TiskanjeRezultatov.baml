   M S B A M L   `   `   `  ���� [  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms   CrossManager_WPF_GUI-   'CrossManager_WPF_GUI.TiskanjeRezultatov   Gwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6x,http://schemas.microsoft.com/winfx/2006/xaml     � Title$  Tiskanje rezultatov��$	��810��$
��Auto�� � WindowStartupLocation$ CenterScreen=�.��� ����  �� ImageSource$ images/Running1.jpg�� j� Stretch$
 Fill=� �� Opacity$	 0.5Q� � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+��� $��0��$��Tiskanje poročil��.���  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� .+��� $��0��$��Izbrana polja��.����  �� Orientation$ Vertical=�.+���  d� 	IsChecked$
 TrueY�{�.  .��	Čas teka�� $
 TrueY�{�.  .��Ime�� $
 TrueY�{�.  .��	Priimek�� -   $��chckbx_startNumber��$��Startna številka��$ FalseY�{�. �� -   $��chckbx_gender��$
��Spol��$ FalseY�{�. �� -   $��chckbx_birth_date��$��Leto rojstva��$ FalseY�{�. �� -   $��chckbx_grade��$��Razred��$ FalseY�{�. �� -   $��chckbx_startGroup��$��Startna skupina��$ FalseY�{�. �� $��1��$��Grupiraj po:��.���� $ Vertical=�$��Center=�.+��� -   $��chckbx_group_birth_date��$��Letu rojstva��$ FalseY�{�. �� -   $��chckbx_group_grade��$��Razredu��$ FalseY�{�. �� -   $��chckbx_group_gender��$��Spolu��$ FalseY�{�. �� -	   $��2��$��Izvozi poročilo tekme���� $��1��$��Tiskanje diplom��.���  �� $
��Auto ��� .+��� $��0��$ Vertical=�.+��� $ 
Horizontal=�.+��� $��Za prvih���� -
   $��drpdwn_numberPrinting���� $
��mest��	� -   $ ��radbtn_crossManagerDiploma��.��CrossManager diploma	� -   $��Poljubna diploma���  �� $
��Auto �$	��108���� $
��Auto �$	��108����  �� �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��0��$��Center=�.��X�� $��1��$��0��$��Center=�.��Y�� $��2��$��0��.��(sredina v mm od spodaj levo)7  1System.Windows.Forms.Integration.WindowsFormsHost  $��0��$��1��	   Child.	 (   "System.Windows.Forms.NumericUpDown  
   Minimum$
 0~�   Maximum$	 210~�-   nud_x_imeSole��  $��1��$��1��.	   $
 0~�$	 297~�-   nud_y_imeSole���� $��2��$��1��$��	Ime šole��  $��0��$��2��.	   $
 0~�$	 210~�-   nud_x_imeTekmovalca��  $��1��$��2��.	   $
 0~�$	 297~�-   nud_y_imeTekmovalca���� $��2��$��2��$��Ime tekmovalca��  $��0��$��3��.	   $
 0~�$	 210~�-   nud_x_besedilo��  $��1��$��3��.	   $
 0~�$	 297~�-   nud_y_besedilo���� $��2��$��3��$��	Besedilo:���� -   $��txtbx_besedilo��$��2��$��4�� �� AcceptsReturn . $	��200��$	��150�� �� TextWrapping$ WrapWithOverflow=�  $��0��$��5��.	   $
 0~�$	 210~�-   nud_x_krajDatum��  $��1��$��5��.	   $
 0~�$	 297~�-   nud_y_krajDatum���� $��2��$��5��$��Kraj in datum:���� -   $��txtbx_krajDatum��$��2��$��6��  $��0��$��7��.	   $
 0~�$	 210~�-   nud_x_mentor��  $��1��$��7��.	   $
 0~�$	 297~�-   nud_y_mentor���� $��2��$��7��$��Mentor:���� -   $��txtbx_mentor��$��2��$��8���� -   $��1��$��Izvozi diplome��� $��2�� �� �� �� .+��� -   $��1��$��Na začetek���� -   $��2��$��Izhod��