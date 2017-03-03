app.service('hanghoaService', function ($http) {
    this.get_hanghoa = function () {
        return $http.get("/api/Api_HanghoaTAHCM").then(function (response) {
            return response.data;
        });
    }
    this.get_nhomhang = function () {
        return $http.get("/api/Api_HangSpTAHCM").then(function (response) {
            return response.data;
        });
    }
    this.add = function (data_add) {
        return $http.post("/api/Api_HanghoaTAHCM", data_add);
    };

    this.save = function (mahanght,data_update) {
        return $http.put("/api/Api_HanghoaTAHCM/" + mahanght, data_update);
    }

    this.delete = function (mahanght, data_delete) {
        return $http.delete("/api/Api_HanghoaTAHCM/" + mahanght,data_delete);
    }
});

app.service('tonkhoService', function ($http) {
    this.get_hangtonkho = function (id) {
        return $http.get("/api/Api_TonkhoTAHCM/" + id).then(function (response) {
            return response.data;
        });
    };
});

app.service('giamdocService', function ($http) {
    this.get_giamdoc = function (username) {
        return $http.get("/api/Api_GiamDocChiNhanhTAHCM/" + username).then(function (response) {
            return response.data;
        });
    }
});

app.service('hangspService', function ($http) {
    this.get_hangsp = function () {
        return $http.get("/api/Api_HangSpTAHCM").then(function (response) {
            return response.data;
        });
    }
});

app.service('khoService', function ($http) {
    this.get_kho = function () {
        return $http.get("/api/Api_KhoTAHCM").then(function (response) {
            return response.data;
        });
    };
    this.add = function (data_add) {
        return $http.post("/api/Api_KhoTAHCM", data_add);
    };

    this.save = function (makho, data_update) {
        return $http.put("/api/Api_KhoTAHCM/" + makho, data_update);
    };

    this.delete = function (makho, data_delete) {
        return $http.delete("/api/Api_KhoTAHCM/" + makho, data_delete);
    };
});

app.service('userService', function ($http) {
    this.get_user = function () {
        return $http.get("/api/Api_NguoidungTAHCM").then(function (response) {
            return response.data;
        });
    };
    this.add = function (data_add) {
        return $http.post("/api/Api_NguoidungTAHCM", data_add);
    };
    this.add_nhanvien = function (nhanvien_add) {
        return $http.post("/api/Api_NhanvienTAHCM", nhanvien_add);
    };

    this.save = function (username, data_update) {
        return $http.put("/api/Api_NguoidungTAHCM/" + username, data_update);
    };

    this.save_nhanvien = function (username, nhanvien_update) {
        return $http.put("/api/Api_NhanvienTAHCM/" + username, nhanvien_update);
    };
});

app.service('nhanvienService', function ($http) {
    this.get_nhanvien = function (username) {
        return $http.get("/api/Api_NhanvienTAHCM/" + username).then(function (response) {
            return response.data;
        });
    };  
});

app.service('phongbanService', function ($http) {
    this.get_phongban = function () {
        return $http.get("/api/Api_PhongbanTAHCM").then(function (response) {
            return response.data;
        });
    };
    this.save = function (maphongban, data_update) {
        return $http.put("/api/Api_PhongbanTAHCM/" + maphongban, data_update);
    };

    this.delete = function (maphongban, data_delete) {
        return $http.delete("/api/Api_PhongbanTAHCM/" + maphongban, data_delete);
    };
});

app.service('nhanvienphongbanService', function ($http) {
    this.get_nhanvien = function (maphongban) {
        return $http.get("/api/Api_Nhanvienphongban/" + maphongban).then(function (response) {
            return response.data;
        });
    };
});

app.service('taikhoanService', function ($http) {
    this.get_taikhoan = function () {
        return $http.get("/api/Api_TaiKhoanHachToanTAHCM").then(function (response) {
            return response.data;
        });
    };
});
