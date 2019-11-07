using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC_AngularTree.Models;

namespace MVC_AngularTree.Controllers.api
{
    public class RolesController : ApiController
    {
        private AngularTreeEntities db = new AngularTreeEntities();

        // GET: api/Roles
        public IHttpActionResult GetRoles()
        {
            object[] objRole = null;
            try
            {
                objRole = (
                        from rl in db.Roles
                        where rl.ParentID == 1 && rl.Child == null
                        select new
                        {
                            RoleID = rl.RoleID,
                            RoleName = rl.RoleName,
                            ParentID = rl.ParentID,
                            Child = rl.Child,
                            collapsed = true,
                            children = from cl in db.Roles
                                       where cl.ParentID == rl.RoleID && cl.Child == 1
                                       select new
                                       {
                                           RoleID = cl.RoleID,
                                           RoleName = cl.RoleName,
                                           ParentID = cl.ParentID,
                                           Child = cl.Child,
                                           collapsed = true,
                                           children = from cld in db.Roles
                                                      where cld.ParentID == cl.RoleID && cl.Child == 1
                                                      select new
                                                      {
                                                          RoleID = cld.RoleID,
                                                          RoleName = cld.RoleName,
                                                          ParentID = cld.ParentID,
                                                          Child = cld.Child,
                                                          collapsed = true
                                                      }
                                       }
                        }).ToArray();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return Json(new
            {
                objRole
            });
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.RoleID)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoleExists(role.RoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role.RoleID }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.Roles.Count(e => e.RoleID == id) > 0;
        }
    }
}