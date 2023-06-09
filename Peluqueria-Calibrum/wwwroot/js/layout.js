﻿function cerrarSesion() {
    document.querySelector('.dropdown-item').addEventListener('click', function (event) {
        event.preventDefault();

        let timerInterval;
        Swal.fire({
            title: 'Cerrando sesión',
            html: '<b></b> segundos.',
            timer: 1000,
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
                const b = Swal.getHtmlContainer().querySelector('b');
                timerInterval = setInterval(() => {
                    b.textContent = ((Swal.getTimerLeft() / 1000).toFixed(1));
                }, 100);
            },
            willClose: () => {
                clearInterval(timerInterval);
            },
            onClose: () => {
                Swal.fire({
                    icon: 'success',
                    title: '¡Has escapado del cierre de sesión!',
                    text: 'Parece que alguien no quiere irse... ¡Sigue disfrutando!',
                    showConfirmButton: false,
                    timer: 3000
                });
            }
        }).then(() => {
            window.location.href = '/Home';
        });
    });
}

window.addEventListener('DOMContentLoaded', function () {
    cerrarSesion();
});