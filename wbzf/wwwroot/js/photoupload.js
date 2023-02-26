function photoSet(d, id) {
    var isOk = true;
    const size = (d.files[0].size / 1024 / 1024).toFixed(2);

    if (size < 0.5) {

        isOk = true;
    } else {
        var msg = "File size must be less than 500kb. This file size is: " + (size * 1024) + "KB";
        alert(msg);
        isOk = false;
    }
    if (!isOk) {
        return isOk;
      
    }
    var input = d;
    var url = $(d).val();
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
        var reader = new FileReader();
       
        reader.onload = function (e) {
            $("#"+id).attr('src', e.target.result);
           
        }
        reader.readAsDataURL(input.files[0]);
    }
    else {
        $("#"+id).attr('src', '/assets/no_preview.png');
    }
}
