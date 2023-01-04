import React, { useState, useEffect } from 'react'
import api from '../api/api'

import { useNavigate } from 'react-router-dom'

import { DataTable } from 'primereact/datatable'
import { Column } from 'primereact/column'
import { Button } from 'primereact/button'
import { Dialog } from 'primereact/dialog'
import MuseumForm from '../components/MuseumForm'

const Museums = () => {
  const navigate = useNavigate()
  const [museums, setMuseums] = useState([])
  const [addModal, toggleAddModal] = useState(false)
  const [editModal, toggleEditModal] = useState(false)
  const [selectedMuseum, setSelectedMuseum] = useState()

  useEffect(() => {
    api.getMuseums(handleMuseums)
  }, [])

  const handleMuseums = (data) => {
    setMuseums(data)
  }

  const hide = () => {
    toggleAddModal(false)
    toggleEditModal(false)
  }

  const handleDetails = (rowData) => {
    // navigate(`/gateway?id=${rowData._id}`)
  }

  const handleDelete = (rowData) => {
    api.deleteMuseum(rowData.museumID, (data) => {
      api.getMuseums(handleMuseums)
    })
  }
  const handleCreate = (museum) => {
    if (museum.name.length) {
      api.createMuseum(museum, onCreate)
    }
  }
  const handleUpdate = (museum) => {
    if (museum.name.length) {
      api.updateMuseum(museum, onUpdate)
    }
  }

  const selectMuseum = (museum) => {
    setSelectedMuseum(museum)
    toggleEditModal(true)
  }

  const onCreate = (data) => {
    museums.push(data)
    toggleAddModal(false)
  }
  const onUpdate = () => {
    api.getMuseums((data) => {
      handleMuseums(data)
      toggleEditModal(false)
    })
  }

  const optionsTemplate = (rowData) => {
    return (
      <div>
        <Button
          // onClick={() => {
          //   handleDetails(rowData)
          // }}
          icon="pi pi-eye"
          iconPos="right"
          className="mr-2 p-button-rounded"
        />
        <Button
          onClick={() => {
            selectMuseum(rowData)
          }}
          icon="pi pi-pencil"
          iconPos="right"
          className="mr-2 p-button-rounded"
        />
        <Button
          className="p-button-danger p-button-rounded"
          onClick={() => {
            handleDelete(rowData)
          }}
          icon="pi pi-trash"
          iconPos="right"
        />
      </div>
    )
  }

  return (
    <div className="p-4">
      <h2 className="mb-3">
        List of museums
        <Button
          icon="pi pi-plus"
          className="p-button-rounded p-button-sm"
          onClick={() => {
            toggleAddModal(true)
          }}
        />
      </h2>
      <Dialog
        header="New Museum"
        visible={addModal}
        style={{ width: '40vw' }}
        modal
        onHide={hide}
      >
        <MuseumForm onSubmit={handleCreate} onCancel={hide} />
      </Dialog>
      <Dialog
        header="Update Museum"
        visible={editModal}
        style={{ width: '40vw' }}
        modal
        onHide={hide}
      >
        <MuseumForm
          onSubmit={handleUpdate}
          onCancel={hide}
          museum={selectedMuseum}
        />
      </Dialog>

      {museums && (
        <DataTable value={museums} responsiveLayout="scroll">
          <Column field="name" header="Name" />
          <Column field="theme" header="Theme" />
          <Column body={optionsTemplate} />
        </DataTable>
      )}
    </div>
  )
}

export default Museums
