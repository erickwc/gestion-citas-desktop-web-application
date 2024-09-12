function funcEliminar(url) {
    Swal.fire({
        title: "Confirmar",
        text: "¿Estas seguro de eliminar el registro seleccionado?",
        showCancelButton: true,
        confirmButtonText: "Confirmar",
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33"
    }).then((result) => {

        if (result.isConfirmed) {
            let form = document.createElement("form");
            form.method = "POST";
            form.action = url;
            document.body.appendChild(form);
            form.submit();
        }

    });
}
