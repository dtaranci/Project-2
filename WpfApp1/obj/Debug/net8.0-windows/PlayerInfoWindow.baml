   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.PlayerInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  PlayerInfoWindow��5   	   $	��500��6"   $	��400��6/    � 	Resources 5         myAnimation �� TargetProperty W� From	 W� To g� Duration��%n   &	        �� 5   
   .��5      W� $ Opacity�6    06B    16K   $ 0:0:0.3D�6R   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� #��[  6   5      .��5      �  � RowDefinitions 5    
   �� 5!      $
��40px �6   �� 5"      $��160px �6   �� 5#      $
��40px �6   �� 5$      $
��40px �6   �� 5%      $
��40px �6   �� 5&      $
��40px �6   �� 5'      $��* �6   	 � ColumnDefinitions	 5)   
   �� 5*      $��100px �6   �� 5+      $��* �6   $	��300��6)   .+�5.   
   �� -   5        
 ��Name$
 imgPlayerImage��5.   �   $��0��6   $��1��6    $��2��6-   $��Center=�6A   $��Center=�6^   $��/Default_image.png��6y   6�   �� 50   
   -   5         ��Name$ 
labeltitle��50   {   $��Player Information��6   $��0��6-   $��0��6:   $��2��6J   $��Center=�6^   6{   �� 52   
   -   5        $ label1��52   Y   $��Name:��6   $��2��6    $��0��6-   $��Right=�6=   6Y   �� 53   
   -   5        $ label2��53   [   $��Number:��6   $��3��6"   $��0��6/   $��Right=�6?   6[   �� 54   
   -   5        $ label3��54   ]   $��	Position:��6   $��4��6$   $��0��61   $��Right=�6A   6]   �� 55   
   -   5        $ label4��55   \   $��Captain:��6   $��5��6#   $��0��60   $��Right=�6@   6\   �� 57   
   -   5         ��Name$ btnClose��57   !   $��Close��6   $
��60px��63   $
��40px��6@   $��15��6N   $��1��6\   $��Right=�6l   $��Bottom=�6�   $��20px 0q�6�   6�   �� 5:   
   -   5        $ lblName��5:   Y   $
��Name��6   $��2��6   $��1��6,   $��Center=�6<   6Y   �� 5;   
   -	   5        $ 	lblNumber��5;   [   $��Number��6   $��3��6!   $��1��6.   $��Center=�6>   6[   �� 5<   
   -
   5        $ lblPosition��5<   ]   $��Position��6   $��4��6#   $��1��60   $��Center=�6@   6]   �� 5=   
   -   5        $ 
lblCaptain��5=   \   $��Captain��6   $��5��6"   $��1��6/   $��Center=�6?   6\   5C      5D      