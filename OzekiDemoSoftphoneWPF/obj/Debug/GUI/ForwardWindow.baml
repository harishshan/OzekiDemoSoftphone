   M S B A M L   `   `   `  ����  OzekiDemoSoftphoneWPF-    'OzekiDemoSoftphoneWPF.GUI.ForwardWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Forward Call��5   	   $	��188��6   $	��300��6+    � WindowStyle$ 
ToolWindow=�67    � WindowStartupLocation$ CenterOwner=�6P    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6�    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      �  � RowDefinitions 5   
   �� 5      $��6 �6   �� 5	      $��40 �6   �� 5
      $��25 �6   �� 5      $��25 �6   �� 5      $
��161* �6    � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      $
��216* �6   .+�5   
   �� -   5        $��tbText��5      $b��\Please specify the phone number or the SIP URI where you want to redirect the selected call.��6"   $��1��6�   $��2��6�   $��38��6�   $��18,0,6,0q�6�   $	��Top=�6�   $
��Wrap=�6�   $��11(�6�   $��Italic$�6   �� 5   
   -   5        $��lTarget��5      $��Target:��6   $��2��61   $��28��6>   $��Right=�6J   $��Center=�6f   �� 5   
   -   5        $��tbForwardTarget��5      $��23��6A   $��1��6M   $��2��6]   $��Center=�6j   $��0,1,6,0q�6�   ��6)   �� *Target+6�   �� 5   
   -   5        $��lExample��5      $'��!Example: 873 or 873@192.168.112.1��6    $��1��6L   $��3��6\   $��Center=�6i   $��Right=�6�   $��Italic$�6�   $��11(�6�   $��0,0,6,0q�6�   �� 5   
   -   5        $��btnOK��5      $��OK��6   $��1��6+   $��4��6;   $��23��6H   $
��Left=�6T   $��0,13,0,0q�6o   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        $��	btnCancel��5      $��Cancel��6"   $��1��63   $��4��6C   $��23��6P   $
��Left=�6\   $��	81,13,0,0q�6w   $	��Top=�6�   $��75��6�   6�   5      5      