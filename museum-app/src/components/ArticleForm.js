import React, { useState, useEffect } from 'react'

import api from '../api/api'

import { InputText } from 'primereact/inputtext'
import { Dropdown } from 'primereact/dropdown'
import { Button } from 'primereact/button'
import { Checkbox } from 'primereact/checkbox'

const ArticleForm = ({ onSubmit, onCancel, article }) => {
  const [name, setName] = useState(article?.name || '')
  const [damaged, setDamaged] = useState(article?.damaged || false)
  const [museum, setMuseum] = useState(article?.museum || '')
  const [museumList, setMuseums] = useState([])

  const handleSubmit = () => {
    if (article) {
      article = Object.assign(article, {
        name,
        damaged,
        museumID: museum.museumID,
      })
      onSubmit(article)
    } else {
      onSubmit({ name, damaged, museumID: museum.muesumID })
    }
  }

  useEffect(() => {
    api.getMuseums(handleMuseums)
  }, [])
  const handleMuseums = (data) => {
    setMuseums(data)
  }

  return (
    <>
      <div className="flex flex-column">
        <h4>Name</h4>
        <InputText value={name} onChange={(e) => setName(e.target.value)} />
        <h4>Museum</h4>
        <Dropdown
          optionLabel="name"
          value={museum}
          options={museumList}
          onChange={(e) => setMuseum(e.value)}
        />
        <div className="my-4">
          <Checkbox
            inputId="cbdamaged"
            onChange={(e) => setDamaged(e.checked)}
            checked={damaged}
          ></Checkbox>
          <label htmlFor="cbdamaged" className="p-checkbox-label ml-2">
            Damaged
          </label>
        </div>

        <div className="flex flex-row-reverse mt-3">
          <Button label="Cancel" icon="pi pi-times" onClick={onCancel} />
          <Button
            className="mr-3"
            label={article ? 'Update' : 'Create'}
            icon="pi pi-check"
            onClick={handleSubmit}
          />
        </div>
      </div>
    </>
  )
}

export default ArticleForm
