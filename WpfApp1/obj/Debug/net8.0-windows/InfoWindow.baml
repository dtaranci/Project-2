   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   H DClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullX<clr-namespace:ClassLibrary1.Resources;assembly=ClassLibrary1ClassLibrary1.Resources 5   	       WpfApp1.InfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   Mprop<clr-namespace:ClassLibrary1.Resources;assembly=ClassLibrary1     5   	     � Title$  
InfoWindow��5	   	   $	��680��6   $	��400��6)    � 	Resources 5         myAnimation3 �� TargetProperty �� From	 �� To g� Duration W� From	 W� To��%�   &	        �� 5   
   .��5      �� $ Background.Color�6    	LightBlue6J   	 White6[   $ 0:0:0.5D�6f   W� 5      $ FontSize�6    186C    126M   5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 Window.Loaded��6   .[�5      �� #��[  6   5      .��5       � 
 � RowDefinitions
 5!   
   �� 5"      $
��40px �6   �� 5#      $
��40px �6   �� 5$      $
��40px �6   �� 5%      $
��40px �6   �� 5&      $
��40px �6   �� 5'      $
��40px �6   �� 5(      $
��40px �6   �� 5)      $
��40px �6   �� 5*      $
��40px �6   �� 5+      $
��40px �6   �� 5,      $
��40px �6   �� 5-      $
��40px �6   �� 5.      $
��40px �6   �� 5/      $
��40px �6   �� 50      $
��40px �6   �� 51      $
��40px �6    � ColumnDefinitions 53   
   �� 54      $��100px �6   �� 55      $��* �6   $	��300��6)   .+�58   
   �� -   5         ��Name$ lblTeamName��58   r   $��	Team Name��6   $��0��6$   $��0��61   $��2��6A   $��Center=�6U   6r   �� 5:   
   &   ClassLibrary1.Resources.Resource	   ID#��Z 6   $��1��66   $��0��6C   $��Right=�6S   �� 5;   
      country#��Z 6   $��2��6;   $��0��6H   $��Right=�6X   �� 5<   
      altname#��Z 6   $��3��6;   $��0��6H   $��Right=�6X   �� 5=   
      fifacode#��Z 6   $��4��6<   $��0��6I   $��Right=�6Y   �� 5>   
      groupid#��Z 6   $��5��6;   $��0��6H   $��Right=�6X   �� 5?   
      groupletter#��Z 6   $��6��6?   $��0��6L   $��Right=�6\   �� 5@   
      wins#��Z 6   $��7��68   $��0��6E   $��Right=�6U   �� 5A   
      draws#��Z 6   $��8��69   $��0��6F   $��Right=�6V   �� 5B   
      losses#��Z 6   $��9��6:   $��0��6G   $��Right=�6W   �� 5C   
      gamesplayed#��Z 6   $��10��6?   $��0��6M   $��Right=�6]   �� 5D   
      points#��Z 6   $��11��6:   $��0��6H   $��Right=�6X   �� 5E   
      goalsfor#��Z 6   $��12��6<   $��0��6J   $��Right=�6Z   �� 5F   
      goalsagainst#��Z 6   $��13��6@   $��0��6N   $��Right=�6^   �� 5G   
      goalsdifferential#��Z 6   $��14��6E   $��0��6S   $��Right=�6c   �� 5H   
   -   5         ��Name$ btnClose��5H   :      close#��Z 6   $
��60px��6L   $
��40px��6Y   $��15��6g   $��1��6u   $��Right=�6�   $��20px 0q�6�   6�   �� 5K   
   -   5        $ lblID��5K   W   $��ID��6   $��1��6   $��1��6*   $��Center=�6:   6W   �� 5L   
   -   5        $ 
lblCountry��5L   \   $��Country��6   $��2��6"   $��1��6/   $��Center=�6?   6\   �� 5M   
   -   5        $ 
lblAltName��5M   ]   $��Alt_name��6   $��3��6#   $��1��60   $��Center=�6@   6]   �� 5N   
   -   5        $ lblFifaCode��5N   ^   $��	Fifa_code��6   $��4��6$   $��1��61   $��Center=�6A   6^   �� 5O   
   -   5        $ 
lblGroupID��5O   ^   $��	Group__ID��6   $��5��6$   $��1��61   $��Center=�6A   6^   �� 5P   
   -   5        $ lblGroupLetter��5P   b   $��Group__letter��6   $��6��6(   $��1��65   $��Center=�6E   6b   �� 5Q   
   -	   5        $ lblWins��5Q   Y   $
��Wins��6   $��7��6   $��1��6,   $��Center=�6<   6Y   �� 5R   
   -
   5        $ lblDraws��5R   Z   $��Draws��6   $��8��6    $��1��6-   $��Center=�6=   6Z   �� 5S   
   -   5        $ 	lblLosses��5S   [   $��Losses��6   $��9��6!   $��1��6.   $��Center=�6>   6[   �� 5T   
   -   5        $ lblGamesPlayed��5T   c   $��Games__played��6   $��10��6(   $��1��66   $��Center=�6F   6c   �� 5U   
   -   5        $ 	lblPoints��5U   \   $��Points��6   $��11��6!   $��1��6/   $��Center=�6?   6\   �� 5V   
   -   5        $ lblGoalsFor��5V   `   $��
Goals__for��6   $��12��6%   $��1��63   $��Center=�6C   6`   �� 5W   
   -   5        $ lblGoalsAgainst��5W   d   $��Goals__against��6   $��13��6)   $��1��67   $��Center=�6G   6d   �� 5X   
   -   5        $ lblGoalsDifferential��5X   i   $��Goals__differential��6   $��14��6.   $��1��6<   $��Center=�6L   6i   5\      5]      