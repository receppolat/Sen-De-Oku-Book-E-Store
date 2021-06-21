function readURL(input, namestr) {
    if (input.files && input.files[0]) {
        var reader = new FileReader()
        reader.onload = function (e) {
            $('#' + namestr).attr('src', e.target.result)
        }
        reader.readAsDataURL(input.files[0])
    }
}
$("#ImageFileName").change(function () {
    readURL(this, 'ImageAdd')
});