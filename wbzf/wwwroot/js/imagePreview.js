
    function openModal(src) {
            var modal = document.getElementById("myModal");
    var modalImg = document.getElementById("img01");
    modal.style.display = "block";
    modalImg.src = src;

    // Close the modal when the modal body is clicked
    modal.onclick = function (event) {
                if (event.target == modal) {
        modal.style.display = "none";
                }
            }
        }

    function closeModal() {
            var modal = document.getElementById("myModal");
    modal.style.display = "none";
        }
