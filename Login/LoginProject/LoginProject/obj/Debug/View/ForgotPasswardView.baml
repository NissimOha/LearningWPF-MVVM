   M S B A M L   `   `   `  ����G  CLoginProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LoginProject.ViewLoginProject.View  5   	   ?$clr-namespace:LoginProject.ViewModelLoginProject.ViewModel  5   	   +clr-namespace:LoginProjectLoginProject  5   	   *    $LoginProject.View.ForgotPasswardView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LoginProject.View     5   	   3vm$clr-namespace:LoginProject.ViewModel     5   	   )lpclr-namespace:LoginProject     5   	     � Title$  שיחזור סיסמה��5
   	   $	��580��6   $	��380��6+    � WindowStartupLocation$ CenterScreen=�67    � DataContext 5      4  .LoginProject.ViewModel.ForgotPasswardViewModel  5   
    � 	Resources 5         myButtonStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��5      .�5      ��  � ��$	 110��5      �� 5       � ��$ 30��5      �� 5       � ��$	 Top=�5      �� 5       � ��$ 10q�5      �� 5       � ��
 ��� �5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��2* �6   �� 5#      $��6* �6   �� 5$      $��* �6   .+�5'   
   �� $��10q�6   $��2��64   ��6   �� *Logo+64   �� 5)   
   $��1��6   .+�5*      �� $��10q�6   $��:תעודת זהות��6$   $��Right=�67   $��25(�6S   �� 5+   
   -   5        $��	idTextBox��5+      $��10q�6   $��30��6/   $��20(�6;    � ToolTip$! .הזן תעודת זהות��6I   	 �� 	MaxLength$	 20��5,   3   ��6   �� *Id+
 �� Mode$
 TwoWay=�63   �� 5.   
   $��10q�6   $��:שם משתמש��6    $��Right=�61   $��25(�6M   �� 5/      -   5        $��userNameTextBox��5/   "   $��10q�6   $��30��69   $��20(�6E   $ .הזן שם משתמש��6S   $	 20��50   9   ��6   �� *
UserName+$
 TwoWay=�69   �� 52      #��[  6   $��שחזר סיסמה��6<   $��Right=�6Q   ��53      �� *RestorePasswordCommand+�� 54      $��20q�6   $��15(�6$   
���\\��$��Right=�6a   ��62   �� *Result+6a   56      �� 58   
   $��2��6   $��10q�6!   $��© Nissim Ohayon��6-   $
��Left=�6D   59      5:      