


var app = angular.module('hanghoaApp', ['angularUtils.directives.dirPagination']);
app.controller('hangHoaCtrl', hangHoaCtrl);
//function nhom hang

app.controller('tonkhoCtrl', tonkhoCtrl);

function tonkhoCtrl($scope, $http) {

        
    
        

    $scope.getTotal = function (type) {
        var total = 0;
        angular.forEach($scope.danhsachtonkho, function (el) {
            total += el[type];
        });
        return total;
    };
}

//function hang hoa
function hangHoaCtrl($scope, $http) {

    $scope.edit = function (item) {
        $scope.item = item;

    }

    $scope.get_tonkho = function (id) {
        $http.get('/api/Api_TonKhoDaiLy/' + id + '/DAI_LY_1').then(function (response) {

            $scope.danhsachtonkho = response.data
        });
    }

    // lấy dữ liệu từ server(hàng hóa)
    $scope.get_hanghoa = function () {
        $http.get("/api/Api_HangHoaDaiLy")
                .then(function (response) {
                    $scope.danhsachhanghoa = response.data;
                });

    }
    // init dữ liệu
    $scope.get_hanghoa();
    //-------------------------------------------------------------



    //hover header
    $scope.mahangHT = false;
    $scope.ma_hang_nhap = false;
    $scope.ten_hang = false;
    $scope.ma_nhom_hang = false;
    $scope.don_vi_tinh = false;
    $scope.model_dac_biet = false;

    $scope.showmahangHT = {
        title: 'Mã đã quy chuẩn và duy nhất trong hợp long'
    };

    $scope.showmahangnhap = {
        title: 'Mã người dùng nhập vào'
    };

    $scope.showtenhang = {
        title: 'Tên hàng hóa'
    };

    $scope.showmanhomhang = {
        title: 'Tên hãng cung cấp'
    };

    $scope.showdonvitinh = {
        title: 'Đơn vị tính'
    };

    $scope.showmodeldacbiet = {
        title: 'Mã có giá đặc biệt'
    };

}

