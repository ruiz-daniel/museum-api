import React, { useState, useEffect } from 'react'

import api from '../api/api'

import { useSearchParams } from 'react-router-dom'

import { Button } from 'primereact/button'
import { Card } from 'primereact/card'
import { Dialog } from 'primereact/dialog'

import ArticleForm from '../components/ArticleForm'

const Museum = () => {
  const [queryParams] = useSearchParams()
  const museumID = queryParams.get('id')
  const [museum, setMuseum] = useState()
  const [selectedArticle, setSelectedArticle] = useState()
  const [addModal, toggleAddModal] = useState(false)
  const [editModal, toggleEditModal] = useState(false)

  const handleMuseum = (museum) => {
    setMuseum(museum)
    hide()
  }

  const handleCreate = (article) => {
    api.createArticle(article, () => {
      api.getMuseum(museumID, handleMuseum)
    })
  }

  const handleDelete = (article) => {
    api.deleteArticle(article.articleID, () => {
      api.getMuseum(museumID, handleMuseum)
    })
  }

  const handleUpdate = (article) => {
    api.updateArticle(article, () => {
      api.getMuseum(museumID, handleMuseum)
    })
  }

  useEffect(() => {
    api.getMuseum(museumID, handleMuseum)
  }, [])

  const hide = () => {
    toggleAddModal(false)
    toggleEditModal(false)
  }

  const footer = (article) => (
    <span>
      <Button
        label="Edit"
        icon="pi pi-pencil"
        style={{ marginRight: '.25em' }}
        onClick={() => {
          setSelectedArticle(article)
          toggleEditModal(true)
        }}
      />
      <Button
        label="Delete"
        icon="pi pi-trash"
        className="p-button-secondary"
        onClick={() => handleDelete(article)}
      />
    </span>
  )

  return (
    <div className="p-5">
      <Dialog
        header="New Article"
        visible={addModal}
        style={{ width: '40vw' }}
        modal
        onHide={hide}
      >
        <ArticleForm
          onSubmit={handleCreate}
          onCancel={hide}
          currentMuseum={museum}
        />
      </Dialog>
      <Dialog
        header="Update Article"
        visible={editModal}
        style={{ width: '40vw' }}
        modal
        onHide={hide}
      >
        <ArticleForm
          onSubmit={handleUpdate}
          onCancel={hide}
          article={selectedArticle}
          currentMuseum={museum}
        />
      </Dialog>
      <h2>
        Articles in {museum?.name || 'Museum'}{' '}
        <Button
          icon="pi pi-plus"
          className="ml-4 p-button-rounded p-button-sm"
          onClick={() => {
            toggleAddModal(true)
          }}
        />
      </h2>
      <div className="flex flex-wrap">
        {museum?.articles.map((article) => {
          return (
            <Card
              key={article.articleID}
              className="mr-4 mb-3"
              footer={footer(article)}
            >
              <div className="text-center">
                <h3>{article.name}</h3>
                <h4 style={{ color: article.damaged ? 'red' : 'green' }}>
                  {article.damaged ? 'Damaged' : 'Good'}
                </h4>
              </div>
            </Card>
          )
        })}
      </div>
    </div>
  )
}

export default Museum
