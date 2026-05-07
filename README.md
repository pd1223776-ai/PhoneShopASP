# PhoneShop MVC

## Tổng quan
PhoneShop là một ứng dụng web bán điện thoại di động xây dựng bằng ASP.NET Core MVC (.NET 8). Dự án mô phỏng chức năng một cửa hàng trực tuyến với giỏ hàng, quản lý sản phẩm, đặt hàng, thanh toán và quản lý người dùng.

## Các tính năng chính
- Đăng ký và quản lý tài khoản người dùng với ASP.NET Identity
- Phân quyền Admin và Customer
- Danh mục sản phẩm và trang chi tiết điện thoại
- Giỏ hàng với tính toán tổng tiền và số lượng
- Đặt hàng bằng hình thức COD / VNPay
- Thanh toán VNPay sandbox
- Lưu trữ session cho giỏ hàng
- Quản lý dữ liệu bằng Entity Framework Core và SQL Server
- Upload và xóa ảnh sản phẩm

## Kiến trúc dự án
- `PhoneShopMVC/`: dự án web chính
- `PhoneShopMVC.DataAccess/`: tầng truy xuất dữ liệu, repository, DbContext
- `PhoneShopMVC.Model/`: định nghĩa model, entity, DTO và ViewModel
- `PhoneShopMVC.Utility/`: helper, cấu hình, email sender, hằng số

## Công nghệ sử dụng
- .NET 8.0
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / LocalDB
- ASP.NET Identity
- VNPay sandbox
- Session và Authenticaiton
- Razor Pages và Views

## Cấu hình chính
Tệp cấu hình: `PhoneShopMVC/appsettings.json`

- `ConnectionStrings:DefaultConnection`: chuỗi kết nối SQL Server LocalDB
- `VNPay:vnp_TmnCode`, `VNPay:vnp_HashSecret`, `VNPay:vnp_Url`, `VNPay:vnp_ReturnUrl`

## Hướng dẫn chạy
1. Mở solution `PhoneShop.sln` bằng Visual Studio hoặc Visual Studio Code.
2. Đảm bảo SQL Server LocalDB đã cài đặt.
3. Thiết lập project `PhoneShopMVC` làm startup project.
4. Chạy ứng dụng.
5. Truy cập `https://localhost:{port}` theo port mà ứng dụng cung cấp.

## Chú ý khi báo cáo
- Ứng dụng sử dụng `PhoneShopMVC.Services.VNPayService` để tạo URL thanh toán VNPay.
- `ApplicationDbContext` khởi tạo dữ liệu mẫu cho các danh mục và sản phẩm.
- Các route chính:
  - `Home/Index`: trang chủ và danh sách sản phẩm
  - `ShoppingCart/Index`: xem giỏ hàng
  - `ShoppingCart/Summary`: thông tin đặt hàng
  - `ShoppingCart/VNPayCheckout`: chuyển sang VNPay

## Các điểm nổi bật
- Thiết kế MVC chuẩn với tách biệt repository và service
- Hỗ trợ thanh toán online qua VNPay sandbox
- Kết hợp Identity và session để quản lý người dùng và giỏ hàng
- Cấu trúc rõ ràng phù hợp trình bày báo cáo

## Liên kết
- Solution: `PhoneShop.sln`
- Project chính: `PhoneShopMVC/PhoneShopMVC.csproj`
- DbContext: `PhoneShopMVC.DataAccess/Data/ApplicationDbContext.cs`
- Thanh toán VNPay: `PhoneShopMVC/Services/VNPayService.cs`
