import React, { useState } from 'react'

import { InputText } from 'primereact/inputtext'
import { Dropdown } from 'primereact/dropdown'
import { Button } from 'primereact/button'

const MuseumForm = ({ onSubmit, onCancel, museum }) => {
  const [name, setName] = useState(museum ? museum.name : '')
  const [theme, setTheme] = useState(museum && museum.theme)

  const themes = ['Art', 'Natural Science', 'History']

  const handleSubmit = () =>  {
    museum ? onSubmit({ museumID: museum.museumID, name, theme}) : onSubmit({name, theme})
    
  }

  return (
    <>
      <div className="flex flex-column">
        <h4>Name</h4>
        <InputText value={name} onChange={(e) => setName(e.target.value)} />
        <h4>Theme</h4>
        <Dropdown
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
