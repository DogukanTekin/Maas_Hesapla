Public Class Form1
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Select Case Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) 'TextBox'a sadece harf ve silme tuşu aktif edildi
            Case True
                e.Handled = False
            Case False
                e.Handled = True
        End Select
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) 'TextBox'a sadece harf ve silme tuşu aktif edildi
            Case True
                e.Handled = False
            Case False
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Select Case Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) 'TextBox'a sadece rakam ve silme tuşu aktif edildi
            Case True
                e.Handled = False
            Case False
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Select Case Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) 'TextBox'a sadece rakam ve silme tuşu aktif edildi
            Case True
                e.Handled = False
            Case False
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Select Case Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) 'TextBox'a sadece rakam ve silme tuşu aktif edildi
            Case True
                e.Handled = False
            Case False
                e.Handled = True
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim maas, kesinti, avans, netmaas As Integer 'ileride kullanmak için 6 adet değişken tanımladım. Gerekli bilgileri textboxlardan değişkenlere aktardım
        Dim ad, soyad As String
        ad = TextBox1.Text
        soyad = TextBox2.Text
        maas = Val(TextBox3.Text)
        kesinti = Val(TextBox4.Text)
        avans = Val(TextBox5.Text)
        netmaas = (maas * 0.68) 'maaşın %32'si otomatik olarak kesildiği için bu satırdaki işlemlerle net maaşı hesapladım
        Select Case maas ' Önce maaş kontrolü yaptım. 
            Case Is < 1000 'Eğer 1000'den küçük ise hata vererek geri yönlendiriyor.
                MessageBox.Show("Maaşınız 1000TL altında olamaz")
                TextBox1.Focus()
                TextBox3.Text = "1000"
                TextBox4.Text = "0"
                TextBox5.Text = "0"
            Case Is > 50000 'Eğer 50000'den büyük ise hata vererek geri yönlendiriyor.
                MessageBox.Show("Maaşınız 50.000TL üzerinde olamaz")
                TextBox1.Focus()
                TextBox3.Text = "1000"
                TextBox4.Text = "0"
                TextBox5.Text = "0"
            Case 1000 To 50000 '1000 ile 50000 TL arasında ise diğer durum kontrollerine geçiyoruz.
                Select Case kesinti Or avans ' kesinti ve avansı aynı select case içerisinde kontrol ediyorum
                    Case Is < 0 ' bunlardan birisi 0'dan düşük ise hangisinin düşük olduğunu kontrol ediyorum
                        Select Case kesinti
                            Case Is < 0 ' eğer kesinti 0'dan düşük ise hata verip kesinti textine 0 yazdırıp oraya geri yönlendiriyoru. 0'ın sebebi program hata vermemesi için default değer
                                MessageBox.Show("0TL'nin altında kesinti olamaz")
                                TextBox1.Focus()
                                TextBox3.Text = "1000"
                                TextBox4.Text = "0"
                                TextBox5.Text = "0"
                        End Select
                        Select Case avans ' kesintide yaptığım işlemlerin aynısı burada da yapılıyor. Hangisinde hata varsa o texte yönlendirip ekrana o hatayı verdiriyorum.
                            Case Is < 0
                                MessageBox.Show("0TL'nin altında avans olamaz")
                                TextBox1.Focus()
                                TextBox3.Text = "1000"
                                TextBox4.Text = "0"
                                TextBox5.Text = "0"
                        End Select
                    Case Is > (netmaas * 0.25) ' kesinti veya avans için 0'dan düşük olma durumunda yaptığım kontrolleri burda %25'ten büyük durumlar için yapıyorum
                        Select Case kesinti
                            Case Is > (netmaas * 0.25)
                                MessageBox.Show("Maaşınızın %25'inden fazlası kesinti olamaz")
                                TextBox1.Focus()
                                TextBox3.Text = "1000"
                                TextBox4.Text = "0"
                                TextBox5.Text = "0"
                        End Select
                        Select Case avans
                            Case Is > (netmaas * 0.25)
                                MessageBox.Show("Maaşınızın %25'inden fazlası avans olamaz")
                                TextBox1.Focus()
                                TextBox3.Text = "1000"
                                TextBox4.Text = "0"
                                TextBox5.Text = "0"
                        End Select
                    Case 0 To (netmaas * 0.25) ' Kesinti veya avans 0 ile netmaaş*0.25 arasındaysa eğer listbox'a ekleme işlemi yapıyorum.
                        'Select Case (netmaas * 12) ' *12 formülü ile hesaplanmıyor Do while döngüsünde maas = maas + maas gibi bir işlem yaptırmam gerekiyordu
                        'Case Is < 24000 ' Bu maaş = maaş + maaş işlemini önce bir sayac değişkeni tanımlayıp select case içerisinde 0 dan 11 e kadar toplam 12 kez tekrarlamak gerekiyor
                        ' Do While döngüsünde sayacı 1 er arttırarak 12 olduğu zaman select caseden çıkması gerekiyor programın
                        ' Örnek olarak Do While (netmaas*0.85)<24000  / netmaas = (netmaas*0.85) + netmaas = (netmaas*0.85) / sayac = sayac+1 / Loop
                        ' Yukarıdaki do while döngüsü kullanılmalı bunun için 
                        ' Gelir hesaplamayı tam olarak anlayamadığım için Asgari geçim indirimi, evli/bekar, çocuk sayısı vs gibi faktörler de devreye giriyor
                        ' O kadar ayrıntılı yapamadım programı
                        Select Case netmaas ' Aylık 2000 den 24.000 e ulaşan çalışanlar için 0.85 den gelir vergisi
                            ' Aylık 2.000 ile 4416 arasında alanlardan 0.80 den gelir vergisi
                            ' Aylık 4416 dan fazla alanlar için 0.73 ten gelir vergisi
                            ' Daha üst gelir vergisin için aylık maaşın 50.000'den büyük olması gerekir. Programda 50.000 limit koyduğumuz için onu ekleme gereksinimi duymadım
                            Case Is < 2000
                                ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.85) - (kesinti + avans)).ToString + " " + "TL")
                            Case 2000 To 4416
                                ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.8) - (kesinti + avans)).ToString + " " + "TL")
                            Case Is > 4416
                                ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.73) - (kesinti + avans)).ToString + " " + "TL")
                        End Select
                        '   ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.85) - (kesinti + avans)).ToString + " " + "TL")
                        'Case 24000 To 53000
                        '   ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.8) - (kesinti + avans)).ToString + " " + "TL")
                        'Case 53000 To 190000
                        '   ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.73) - (kesinti + avans)).ToString + " " + "TL")
                        'Case 190000 To 650000
                        '   ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.65) - (kesinti + avans)).ToString + " " + "TL")
                        'Case Is > 650000
                        '   ListBox1.Items.Add(ad + " " + soyad + " " + ((netmaas * 0.6) - (kesinti + avans)).ToString + " " + "TL")
                        'End Select
                End Select
        End Select
        TextBox1.Clear() ' Yeni veri girişi için kullanıcı yerine gerekli textboxları clearlayıp textbox1'e yönlendiriyorum.
        TextBox2.Clear()
        TextBox3.Text = "1000" 'Form loadda yaptığım default değer işlemlerini yeni kayıt için yeniden giriyorum
        TextBox4.Text = "0"
        TextBox5.Text = "0"
        TextBox1.Focus()
        ad = "" ' Yeni veri girerken eski verilerle karışıklık olmaması için bütün değişkenlerimin içerisindeki değerleri temizleyip kullanıcıdan yeni veri alıyorum.
        soyad = ""
        maas = "0"
        netmaas = "0"
        kesinti = "0"
        avans = "0"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        TextBox3.Text = "1000"
        TextBox4.Text = "0"
        TextBox5.Text = "0"
    End Sub
End Class
