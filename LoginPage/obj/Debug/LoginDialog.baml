   M S B A M L   `   `   `  ����G  CBookStoreGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BookStoreGUIBookStoreGUI  5   	       BookStoreGUI.LoginDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BookStoreGUI     5   	     � Title$  Login��5   	   $	��170��6   $	��310��6$   .��5	      � $
��Left=�6   $	��130��6&   $	��Top=�63   $	��290��6K    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6    $��2q�6-   .��69   	Username:6D   �� 5   
   -   5        $��nameTextBox��5      $��1��6%   $��0��65   $��2q�6B   �� 5   
   $��0��6   $��1��6    $��2q�6-   .��69   	Password:6D   G� 5   
   -   5        $��passwordTextBox��5      $��1��6-   $��1��6=   $��2q�6J   �� 5   
   $��1��6   $��1��6%   $��2��69    �� Orientation$ 
Horizontal=�5      $��Center=�6.   .+�5      �� -   5        $��okButton��5       �� 	IsDefault . $��80��5      $��0,10,5,5q�6'   .��69   OK6=   �� 5      -   5        $��cancelButton��5       �� IsCancel . $��80��5      $��	40,10,5,5q�6'   .��6:   Cancel6B   5       �� 5!   
   -   5        $��registerButton��5"      $��1��5!      $��3��6!   $��Center=�6.    . $��80��5#      $��0,5,5,10q�6'   .��69   Register Here6H   5$      5%      