   M S B A M L   `   `   `  ����  BookStoreGUI    BookStoreGUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � Title$ F21's BookStore��5   	   $	��500��6!   $	��920��6.   .��5
      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   � $��0,0,0,-8q�6   .+�5      �� $��Bottom=�6   $��Stretch=�63   $��
43,0,45,33q�6Q   
�������$��24��6x   .@�5      �� -   5         ��Name$ statusTextBlock��5      �� 67   $1�+Please login before proceeding to checkout.��6;   6q   5      �� 5      $��F21BookStore��6   $��Center=�6,   $��Right=�6G   
�������$��22(�6v   $��0,38,123,441q�6�   �� 5      -   5         ��Name$ 
LayoutRoot��5       �� Orientation$ Vertical=�6E   $
��Left=�6\   $
��auto��6w   $	��532��6�   $��4,-1,0,1q�6�    � DataContext 6-   �� .+�5      �� $ 
Horizontal=�6   $��right=�66   .+�5      �� 
�������$��Categories:��6/   $��18,0,0,0q�6E   �� 5      -   5        	 ��Name$	 categoriesComboBox��5   7   $
 �� IsSynchronizedWithCurrentItem$

 TrueY�5       �� DisplayMemberPath$
 Name��5      $��23��6    $��12q�6,   $	��200��68   ��5      �� ��5      �� 5      .R�5   "   $� 5      5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ProductsDataGrid��5!         AutoGenerateColumns .  $	��165��5   7      RowDetailsVisibilityMode$ VisibleWhenSelected=�5!      $	��490��5"      $
��Left=�6   $��
20,0,20,10q�6*      SelectionMode$ Single=�5#      ���#635F7D��5       �� *
drCat_Book+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        titleColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Title��5'         Width5  /System.Windows.Controls.DataGridLengthConverter$	 50* 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5&      �� *Title+5'        5(      -   5        authorColumn��$ Author��5*      $	 18* 6    5)      �� *Author+5*        5+      -   5        priceColumn��$ Price��5-      $	 12* 6      CanUserSort .   5,      �� *Price+5-        5.      -	   5        
yearColumn��$
 Year��50      $ 8* 6    5/      �� *Year+50      52      �� 53      $ Vertical=�6   .+�54      �� -
   5         ��Name$ orderListView��54      $	��150��66   $	��490��6F    �� SelectionMode$ Single=�55      ���#635F7D
���������6   ��  �� View 56      �� 57      .P�58   "   ��  �� Width$ 80��61   $
��ISBN��6<    �� DisplayMemberBinding 59      �� *BookID+�� 5:   "   $	 285��61   $��Title��6=    5;      �� *	BookTitle+�� 5<   "   $ 60��61   $��Quantity��6<    5=      �� *
Quantity+�� 5>   "   $ 60��61   $��Subtotal��6<    5?      �� *
SubTotal+5@      5B      5C      �� 5D      $ 
Horizontal=�6   $��Center=�66   $��10, 10, 10, 10q�6S   $��29��6k   $	��512��6w    J� RenderTransformOrigin$ 0.498,-0.073&�6�   z�5E      V� 5F      .~�5G      �� �� 5H      �� 5I      T� 5J       T� Y$ -6Q�61   5K      .+�5N      �� -   5         ��Name$ 	addButton��5N      $��25��60   $��80��6?   $��Add Book��6M   6`   �� 5O      -   5        $ removeButton��5O      $��25��63   $��80��6B   $��Remove Book��6P   $��10,0,0,0q�6�   �� 5P      -   5        $ calculateBtn��5P      $��Calculate Total��63   $��25��6M   $��80��6\   $��20,0,0,0q�6k   6}   �� 5Q      $��Total ��6   $��20,0,0,0q�6-   
�������6?   �� 5R      -   5         ��Name$ txtTotal��5R      $��22��60    �� TextWrapping$
 Wrap=�6<   $��0��6P   $��59��6Y   
���iii�
������� �� SelectionOpacity$ 0Q�6�   �� 5S      -   5        $ checkoutOrderButton��5S      $��25��6:   $��80��6I   $��Proceed to Checkout��6W   $	��121��6�   $��0,0,0,0q�6�   5T      5U      �� 5V      -   5        $ loginButton��5V   %   $��Login��6   $��674,179,93,280q�6:    	  round#��[  6l   6�   �� 5W      -   5        $ 
exitButton��5W   $   $
��Exit��6   $��674,364,93,97q�68   #��[  6h   6�   �� 5X      -   5        $ 	myAccount��5X      $��25��6(   $��80��67   $��
My Account��6E   $��671,95,93,358q�6w   #��[  6�   6�   �� 5Y      -   5        $ myADmin��5Y      $��25��6&   $��80��65   $��Admin��6C   $��674,260,93,200q�6o   #��[  6�   6�   5Z      5[      5\      