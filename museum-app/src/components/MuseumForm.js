import React, { useEffect, useState } from 'react'

import { InputText } from 'primereact/inputtext'
import { Dropdown } from 'primereact/dropdown'
import { Button } from 'primereact/button'
import api from '../api/api'

const MuseumForm = ({ onSubmit, onCancel, museum }) => {
  const [name, setName] = useState(museum ? museum.name : 'New Museum')
  const [theme, setTheme] = useState(museum && museum.theme)
  const [themes, setThemes] = useState([])

  useEffect(() => {
    api.getThemes(setThemes)
  }, [])

  const handleSubmit = () => {
    museum
      ? onSubmit({ museumID: museum.museumID, name, theme })
      : onSubmit({ name, theme })
  }

  return (
    <>
      <div className="flex flex-column">
        <h4>Name</h4>
        <InputText value={name} onChange={(e) => setName(e.target.value)} />
        <h4>Theme</h4>
        <Dropdown
          optionLabel="name"
          value={theme}
          options={themes}
          onChange={(e) => setTheme(e.value)}
        />
        <div className="flex flex-row-reverse mt-3">
          <Button label="Cancel" icon="pi pi-times" onClick={onCancel} />
          <Button
            className="mr-3"
            label={museum ? 'Update' : 'Create'}
            icon="pi pi-check"
            onClick={handleSubmit}
          />
        </div>
      </div>
    </>
  )
}

export default MuseumForm
