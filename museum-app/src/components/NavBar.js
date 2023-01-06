import React, { useState, useRef } from 'react'

import { Toolbar } from 'primereact/toolbar'

import { Link } from 'react-router-dom'

const NavBar = () => {
  const leftContents = (
    <React.Fragment>
      <div className="mr-4">
        <Link to="/">All Museums</Link>
      </div>
      <div className="mr-4">
        <Link to="/?theme=2">History Museums</Link>
      </div>
      <div className="mr-4">
        <Link to="/?theme=1">Art Museums</Link>
      </div>
      <div className="mr-4">
        <Link to="/?theme=3">Natural Science Museums</Link>
      </div>
    </React.Fragment>
  )

  return (
    <Toolbar left={leftContents} />
  )
}

export default NavBar
