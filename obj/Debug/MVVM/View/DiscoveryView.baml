   M S B A M L   `   `   `  ����E  Ap4_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:p4_projekt.MVVM.Viewp4_projekt.MVVM.View  5      (    "p4_projekt.MVVM.View.DiscoveryView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:p4_projekt.MVVM.View     5      
��� � �.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  restaurantDataGrid��5         AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserResizeColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID Restauracji��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *RestaurantID+6^     5      $	 Otwarte��6%   $

 Auto 6S    66   �� *
Isclosed+6S     5      $	 Nazwa Restauracji��6%   $

 Auto 6e    6@   �� *Nameofrestaurant+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5       $	 Url zdjęcia��6)   $
 90 6>      CellTemplate 5!      �� 5"      .R�5#      �� �� 5$   "   -   5        ��5$   ,   �� *Imageurlofrestaurant+.�6�   .�5%   &   �� $
��None{�6V   
����  ���60   �� *Imageurlofrestaurant+6m   5&   #   5'      5(      5*        5,      $	 Url restauracji��6)   $
 90 6B    5-      �� 5.      .R�5/      �� �� 50   "   -   5        ��50   ,   �� *Urlofrestaurant+.�6�   .�51   &   �� $
��None{�6Q   
����  ���60   �� *Urlofrestaurant+6h   52   #   53      54      56        58      $	 Ilość ocen��6%   $

 Auto 6Y    69   �� *Reviewcount+6Y     59      $	 Ocena��6%   $

 Auto 6O    64   �� *Rating+6O     5:      $
	 Cena��6%   $

 Auto 6M    63   �� *Price+6M     5;      $	 Adres restauracji��6%   $

 Auto 6g    6@   �� *Adressofrestaurant+6g     5<      $	 Miasto��6%   $

 Auto 6N    65   �� *City+6N     5=      $	 Nr.Telefonu��6%   $

 Auto 6Z    6:   �� *Phonenumber+6Z     5?      $	 Szerokość geograficzna��6%   $

 Auto 6b    6E   �� *
Latitude+6b     5@      $	 Długość geograficzna��6%   $

 Auto 6b    6C   �� *
Longtitude+6b     5B      $	 Lokalizacja��6)   $
 90 6>    5C      �� 5D      .R�5E      �� �� 5F   "   -   5        ��5F   ,   �� *LocalizationMapURL+.�6�   .�5G   &   �� $
��None{�6T   
����  ���60   �� *LocalizationMapURL+6k   5H   #   5I      5J      5L        5O      $	 Zapisz��6)   $

 Auto 69    5P      �� 5Q      .R�5R      �� -   5        $��Zapisz��5R   %   66   5S      5U      5W      5[      5\      