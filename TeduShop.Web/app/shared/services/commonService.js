/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('commonService', commonService);

    function commonService()
    {
        return {
            getSeoTitle: getSeoTitle
        };

        function getSeoTitle(input)
        {
            if(input == undefined || input =='')
            {
                return '';
            }
            else
            {
                var slug = input.toLowerCase();

                //Chuyển Ký Tự Có Dấu Thành Không Dấu
                slug = slug.replace(/á|à|ả|ã|ạ|ă|â|ắ|ằ|ẳ|ẵ|ặ|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
                slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
                slug = slug.replace(/í|ỉ|ì|ĩ|ị/gi, 'i');
                slug = slug.replace(/ó|ỏ|ò|õ|ọ|ơ|ô|ớ|ở|ờ|ỡ|ợ|ố|ổ|ồ|ỗ|ộ/gi, 'o');
                slug = slug.replace(/ú|ủ|ù|ũ|ụ|ư|ừ|ử|ừ|ữ|ự/gi, 'u');
                slug = slug.replace(/ý|ỷ|ỳ|ỹ|ỵ/gi, 'y');
                slug = slug.replace(/đ/gi, 'd');

                //Xóa Ký Tự Đặc Biệt
                slug = slug.replace(/\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\/|\?|\<|\>|\,|\.|\;|\"|\'|\[|\]|\{|\}|\:|\_|\\/gi, '');

                //Đổi Khoảng Trằng Thành -
                slug = slug.replace(/ /gi, '-');

                //Phòng Trường Hợp Khách Hàng Nhập Nhiều Ký Tự Khoảng Trống
                slug = slug.replace(/\-{2,}/gi, '-');

                //Xóa Các Ký Tự Gạch Ngang Ở Đầu Và Cuối
                slug = '@'+slug+'@'
                slug = slug.replace(/\@\-|\-\@|\@/gi,'');

                return slug;
            }
        }
    }
})(angular.module('tedushop.common'));