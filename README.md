### Web_BanNuocHoa

### Đồ án lập trình web nâng cao @@
## Thành viên:
- Đỗ Kiên Quyết
- Đỗ Khắc Tú
- Lê Đăng Quân
- Vương Đình Trang
- Phùng Phương Lan
- Ma Đức Mạnh
## Cách sử dụng 
b1: cài đặt visual studio , sql server 
b2: mở visual studio-> new project paste link git repo vào và clone 
b3: mở folder trong visual studio
b4: mở sql server-> kết nối -> right click -> backup database
b5: thiết lập đường dẫn kết nối database trong file web.cofig tìm đến

  <add name="WebNuocHoa_TQEntities4" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=YourSever;initial catalog=WebNuocHoa_TQ;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
thay đổi datasoure = tên server name trong sql server 

b6: quay lại visual studio ctrl + f5 để chạy chế độ không debug 

the end!
## Link Web_BanNuocHoa
http://quyetvippro22-001-site1.atempurl.com/
