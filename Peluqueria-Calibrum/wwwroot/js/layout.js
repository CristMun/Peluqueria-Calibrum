function cerrarSesion() {
    document.addEventListener('keydown', function (event) {
        if (event.ctrlKey && event.key === 's') {
            event.preventDefault(); // Prevenir el comportamiento predeterminado de guardar la página
        }
    });

    document.querySelector('.dropdown-item').addEventListener('click', function (event) {
        event.preventDefault();

        let timerInterval;
        Swal.fire({
            title: 'Cerrando sesión',
            html: 'Espera, ¿¡QUE?! <br><b></b> segundos.',
            timer: 2000,
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

cerrarSesion();
              