   M S B A M L   `   `   `  ����G  CLoginProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LoginProject.ViewLoginProject.View  5      ?$clr-namespace:LoginProject.ViewModelLoginProject.ViewModel  5      +clr-namespace:LoginProjectLoginProject  5      !    LoginProject.View.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LoginProject.View     5      3vm$clr-namespace:LoginProject.ViewModel     5      )lpclr-namespace:LoginProject     5        � DataContext  5      +   %LoginProject.ViewModel.LoginViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��6* �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   ��6   �� *Logo+�� 5   
   $��1��6   $��10q�6"    �� Orientation$ Vertical=�6.   .+�5      �� $��10q�6   $��:שם משתמש��6$   $��Right=�65   $��25(�6Q   �� 5      -   5        $��userNameTextBox��5   "   $��10q�6   $��30��69   $��20(�6E    � ToolTip$ .הזן שם משתמש��6S    �� 	MaxLength$ 20��5   =   ��6   �� *
UserName+ �� Mode$ TwoWay=�6=   �� 5      $��10q�6   $��:סיסמה��6$   $��Right=�62   $��25(�6N   G� 5      -   5        $��passTextBox��5   &   $��10q�6   $��30��69   $��20(�6E   $ .הזן סיסמה��6S   !   LoginProject.PasswordHelper   Attach .  G� 	MaxLength$ 10��5    \      Password 6   �� 	 �� Path$	 Password�$ TwoWay=�6\   �� 5"      $ 
Horizontal=�6   .+�5#      �� $��זכור אותי��6   $��10,20,185,0q�6/   $
��Left=�6D   
 d� 	IsChecked
 5$      �� *IsRememberMe+$ TwoWay=��� 5%      $��10q�6   $��
התחבר��6%   $��80��65   $��30��6@   ��6L   �� *LoginCommand+5&      �� 5(      $��10q�6   �� 6%   $��15(�6/   
����  � �� Command 6=   �� *ForgotPasswordCommand+.�5)   B   שכחתי סיסמה6O   6[   �� 5+      $��10q�6   �� 6%   $��15(�6/   
����  � 6=   �� *SignUpCommand+.�5,   B   
הירשם6I   6U   5.      �� 50   
   $��2��6   $��10q�6!   $��© Nissim Ohayon��6-   $
��Left=�6D   52      53      